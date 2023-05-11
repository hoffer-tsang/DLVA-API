/*==============================================================================
 *
 * Cameras Controller for cameras related API
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using EntityFrameWorkModel;
using System.Data.Entity;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace WebAPI.Controllers
{
    /// <summary>
    /// cameras Controller class that contain all api control for cameras.
    /// </summary>
    [Route("api/v1/cameras")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private string _ANPRCamera = "ANPR";
        private string _SpeedCamera = "Speed Camera";
        private string _TrafficLightCamera = "Traffic Light Camera";
        /// <summary>
        /// get the cameras detail of the specific cameras Id
        /// </summary>
        /// <param name="id"> cameras id of thecameras </param>
        /// <returns> the cameras details with corresponding cameras id </returns>
        //GET: api/v1/cars/{CarId}
        [HttpGet("{id}")]
        public ActionResult<Cameras> GetCamera(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var camera = context.Cameras.Find(id);

                if (camera == null)
                {
                    return NotFound();
                }

                return CameraToCameraModel(camera);
            }
        }
        /// <summary>
        /// get the sightings detail of the specific cameras Id
        /// </summary>
        /// <param name="id"> cameras id of the cameras </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> the sightings details with corresponding cameras id </returns>
        //GET: api/v1/cars/{CarId}
        [HttpGet("{id}/sightings")]
        public ActionResult<SightingsList> GetCameraSightings(int? id, int pageNumber = 1, int itemPerPage = 5)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            if (!PaginationCheck(pageNumber, itemPerPage))
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                if (context.Cameras.Find(id) == null)
                {
                    return NotFound();
                }
                var sightings = context.Sightings.Where(s => s.CameraId == id);
                var totalAvailableItem = sightings.Count();
                var sightingsList = sightings.OrderBy(s => s.SightingId).Skip((pageNumber - 1) * itemPerPage).Take(itemPerPage).ToList();
                var sightingModel = new List<Sightings>();
                foreach (var sighting in sightingsList)
                {
                    sightingModel.Add(SightingToSightingsAPIModel(sighting));
                }
                var returnList = new SightingsList();
                returnList.Sightings = sightingModel;
                returnList.TotalAvailabeItem = totalAvailableItem;
                return returnList;
            }
        }
        /// <summary>
        /// Perform Camera Search by filter then longitude and latitude
        /// </summary>
        /// <param name="longitudeFrom"> camera longitude filter from this value </param>
        /// <param name="longitudeTo"> camera longitude filter to this value  </param>
        /// <param name="latitudeFrom"> camera latitude filter from this value  </param>
        /// <param name="latitudeTo"> camera latitude filter to this value  </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> cameras details that match the search filter </returns>
        [HttpGet]
        public ActionResult<CameraList> GetCamera(decimal? longitudeFrom, decimal? longitudeTo, decimal? latitudeFrom, decimal? latitudeTo, int pageNumber = 1, int itemPerPage = 5)
        {
            if (!SearchUnprocessableCheck(longitudeFrom, longitudeTo, latitudeFrom, latitudeTo))
            {
                return UnprocessableEntity();
            }
            if (!PaginationCheck(pageNumber, itemPerPage))
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                IQueryable<Camera> cameras = context.Cameras;
                if(longitudeFrom != null)
                {
                    cameras = cameras.Where(c => c.Longitude >= longitudeFrom);
                }
                if (longitudeTo != null)
                {
                    cameras = cameras.Where(c => c.Longitude <= longitudeTo);
                }
                if (latitudeFrom != null)
                {
                    cameras = cameras.Where(c => c.Latitude >= latitudeFrom);
                }
                if (latitudeTo != null)
                {
                    cameras = cameras.Where(c => c.Latitude <= latitudeTo);
                }
                var totalAvailableItem = cameras.Count();
                var camerasList = cameras.OrderBy(s => s.CameraId).Skip((pageNumber - 1) * itemPerPage).Take(itemPerPage).ToList();
                var camerasModel = new List<Cameras>();
                foreach (var camera in camerasList)
                {
                    camerasModel.Add(CameraToCameraModel(camera));
                }
                var returnList = new CameraList();
                returnList.Cameras = camerasModel;
                returnList.TotalAvailabeItem = totalAvailableItem;
                return returnList;
            }
        }
        /// <summary>
        /// Update the Camera Details in database
        /// </summary>
        /// <param name="input"> inputModel for camera Put API </param>
        /// <returns> return the get api of the updated camera along with the camera details </returns>
        //PUT: api/camera APIModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Cameras> PutCamera(CameraPutInput input)
        {
            if (!InputDetailsBadRequestCheck(true, input.CameraId, input.RoadName!,
                input.Longitude, input.Latitude, input.AddressId, input.CameraType!))
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(input.RoadName!, input.RoadNumber!,
                input.Longitude, input.Latitude, input.CameraType!, input.CameraLimitValue))
            {
                return UnprocessableEntity();
            }
            if (!InputDetailsNotFoundCheck(input.AddressId))
            {
                return NotFound();
            }
            using (var context = new DVLAEntities())
            {
                var camera = context.Cameras.Find(input.CameraId);
                if(camera == null)
                {
                    return NotFound();
                }
                camera = CameraDetailsInput(camera,
                    input.RoadName!, input.RoadNumber!,
                input.Longitude, input.Latitude, input.AddressId);
                context.SaveChanges();
                var speedCamera = context.SpeedCameras.Find(input.CameraId);
                var trafficLightCamera = context.TrafficLightCameras.Find(input.CameraId);
                switch (input.CameraType)
                {
                    case "ANPR":
                        if (speedCamera != null || trafficLightCamera != null)
                        {
                            return UnprocessableEntity();
                        }
                        break;
                    case "Speed Camera":
                        if (speedCamera == null)
                        {
                            return UnprocessableEntity();
                        }
                        speedCamera.CameraId = camera.CameraId;
                        speedCamera.SpeedMphLimit = (byte)input.CameraLimitValue!;
                        break;
                    case "Traffic Light Camera":
                        if (trafficLightCamera == null)
                        {
                            return UnprocessableEntity();
                        }
                        trafficLightCamera.CameraId = camera.CameraId;
                        trafficLightCamera.SecondsAfterRedLightThreshold = (byte)input.CameraLimitValue!;
                        break;
                }
                context.SaveChanges();
                return GetCamera(camera.CameraId);
            }
        }
        /// <summary>
        /// Post API action to add camera to the database 
        /// </summary>
        /// <param name="input"> inputModel for camera Post API </param>
        /// <returns> get API with the new camera id just add to database </returns>
        // POST: api/cameraAPIModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Cameras> PostCamera(CameraPostInput input)
        {
            if (!InputDetailsBadRequestCheck(false, 1, input.RoadName!,
                input.Longitude, input.Latitude, input.AddressId, input.CameraType!))
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(input.RoadName!, input.RoadNumber!,
                input.Longitude, input.Latitude, input.CameraType!, input.CameraLimitValue))
            {
                return UnprocessableEntity();
            }
            if (!InputDetailsNotFoundCheck(input.AddressId))
            {
                return NotFound();
            }
            Camera camera = new EntityFrameWorkModel.Camera();
            using (var context = new DVLAEntities())
            {
                context.Cameras.Add(camera);
                camera = CameraDetailsInput(camera,
                    input.RoadName!, input.RoadNumber!,
                input.Longitude, input.Latitude, input.AddressId);
                context.SaveChanges();
                switch (input.CameraType)
                {
                    case "ANPR":
                        break;
                    case "Speed Camera":
                        var speedCamera = new SpeedCamera();
                        context.SpeedCameras.Add(speedCamera);
                        speedCamera.CameraId = camera.CameraId;
                        speedCamera.SpeedMphLimit = (byte)input.CameraLimitValue!;
                        break;
                    case "Traffic Light Camera":
                        var trafficLightCamera = new TrafficLightCamera();
                        context.TrafficLightCameras.Add(trafficLightCamera);
                        trafficLightCamera.CameraId = camera.CameraId;
                        trafficLightCamera.SecondsAfterRedLightThreshold = (byte)input.CameraLimitValue!;
                        break;
                }
                context.SaveChanges();
                return GetCamera(camera.CameraId);
            }
        }
        /// <summary>
        /// Check for 422 unprocessable entity error 
        /// </summary>
        /// <param name="longitudeFrom"> camera longitude filter from this value </param>
        /// <param name="longitudeTo"> camera longitude filter to this value  </param>
        /// <param name="latitudeFrom"> camera latitude filter from this value  </param>
        /// <param name="latitudeTo"> camera latitude filter to this value  </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool SearchUnprocessableCheck(decimal? longitudeFrom, decimal? longitudeTo, decimal? latitudeFrom, decimal? latitudeTo)
        {
            if (longitudeFrom != null && (longitudeFrom.ToString()!.Length > 8 || (int)(longitudeFrom * 1000000 % 10) != 0))
            {
                return false;
            }
            else if (longitudeTo != null && (longitudeTo.ToString()!.Length > 8 || (int)(longitudeTo * 1000000 % 10) != 0))
            {
                return false;
            }
            else if (latitudeFrom != null && (latitudeFrom.ToString()!.Length > 8 || (int)(latitudeFrom * 1000000 % 10) != 0))
            {
                return false;
            }
            else if (latitudeTo != null && (latitudeTo.ToString()!.Length > 8 || (int)(latitudeTo * 1000000 % 10) != 0))
            {
                return false;
            }
            else if (longitudeTo < longitudeFrom)
            {
                return false;
            }
            else if (latitudeTo < latitudeFrom)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Convert camera from database to the output format for API AddressModel
        /// </summary>
        /// <param name="camera"> the camera from database </param>
        /// <returns> the camera details with the camera model </returns>
        private Cameras CameraToCameraModel(Camera camera)
        {
            var cameraModel = new Cameras
            {
                CameraId = camera.CameraId,
                RoadName = camera.RoadName,
                Longitude = camera.Longitude,
                Latitude = camera.Latitude,
            };
            if (camera.RoadNumber != null)
            {
                cameraModel.RoadNumber = camera.RoadNumber;
            }
            if (camera.AddressId != null)
            {
                cameraModel.AddressId = camera.AddressId;
            }
            if(camera.SpeedCamera == null && camera.TrafficLightCamera == null)
            {
                cameraModel.CameraType = _ANPRCamera;
            }
            else if(camera.SpeedCamera != null)
            {
                cameraModel.CameraType = _SpeedCamera;
                cameraModel.CameraTypeLimitValue = camera.SpeedCamera.SpeedMphLimit;
            }
            else if(camera.TrafficLightCamera != null)
            {
                cameraModel.CameraType = _TrafficLightCamera;
                cameraModel.CameraTypeLimitValue = camera.TrafficLightCamera.SecondsAfterRedLightThreshold;
            }
            return cameraModel;
        }
        /// <summary>
        /// Convert from sightings entity framework model to api sightings model 
        /// </summary>
        /// <param name="sighting"> sightings details in entity framework model </param>
        /// <returns> sightings details in api model </returns>
        private Sightings SightingToSightingsAPIModel(Sighting sighting)
        {
            var sightingModel = new Sightings
            {
                SightingId = sighting.SightingId,
                CarId = sighting.CarId,
                CameraId = sighting.CameraId,
                SightingTime = sighting.SightingTime
            };
            if (sighting.SecondsAfterRedLight != null)
            {
                sightingModel.SecondsAfterRedLight = sighting.SecondsAfterRedLight;
            }
            if (sighting.SpeedMph != null)
            {
                sightingModel.SpeedMph = sighting.SpeedMph;
            }
            if (sighting.Fine != null)
            {
                sightingModel.DateIssued = sighting.Fine.DateIssued;
                if (sighting.Fine.DatePaid != null)
                {
                    sightingModel.DatePaid = sighting.Fine.DatePaid;
                }
            }
            return sightingModel;
        }
        /// <summary>
        /// Check the pagination parameters input
        /// </summary>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> false if fail search check, otherwise true </returns>
        private bool PaginationCheck(int pageNumber, int itemPerPage)
        {
            if (pageNumber < 1)
            {
                return false;
            }
            if (itemPerPage < 1)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check for Bad Request 400 error 
        /// </summary>
        /// <param name="isPutAPI"> is this a put api or not</param>
        /// <param name="cameraId"> id of the camera </param>
        /// <param name="roadName"> road name of the camera </param>
        /// <param name="longitude"> longitude of the camera </param>
        /// <param name="latitude"> latitude of the camera </param>
        /// <param name="addressId"> id of the camera address</param>
        /// <param name="cameraType"> type of camera </param> 
        /// <returns> false if fail search check, otherwise true </returns>
        private bool InputDetailsBadRequestCheck(bool isPutAPI, int? cameraId,
            string roadName, decimal? longitude, decimal? latitude, int? addressId, string cameraType)
        {
            if (isPutAPI)
            {
                if (cameraId == null || cameraId <= 0)
                {
                    return false;
                }
            }
            else if (roadName == null || longitude == null || latitude == null || cameraType == null)
            {
                return false;
            }
            else if (addressId != null && addressId < 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check for Unprocessable Entity 422 Error
        /// </summary>
        /// <param name="roadName"> road name of the camera  </param>
        /// <param name="roadNumber"> road number of the camera </param>
        /// <param name="longitude"> longitude of the camera </param>
        /// <param name="latitude"> latitude of the camera </param>
        /// <param name="cameraType"> type of camera </param> 
        /// <param name="cameraLimitValue"> the threshold value of the camera </param>
        /// <returns> false if fail search check, otherwise true </returns>
        private bool InputDetailsUnprocessableCheck(string roadName, string? roadNumber, decimal longitude, decimal latitude, string cameraType, byte? cameraLimitValue)
        {
            if (roadName.Length > 50)
            {
                return false;
            }
            else if(roadNumber != null && roadNumber.Length > 5)
            {
                return false;
            }
            else if (longitude.ToString()!.Length > 8 || (int)(longitude * 1000000 % 10) != 0)
            {
                return false;
            }
            else if (latitude.ToString()!.Length > 8 || (int)(latitude * 1000000 % 10) != 0)
            {
                return false;
            }
            else if (cameraType != _ANPRCamera && cameraType != _SpeedCamera && cameraType != _TrafficLightCamera)
            {
                return false;
            }
            else if ((cameraType == _ANPRCamera && cameraLimitValue != null)
                || (cameraType == _SpeedCamera && cameraLimitValue == null)
                || (cameraType == _TrafficLightCamera && cameraLimitValue == null))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check for Not found 404 error 
        /// </summary>
        /// <param name="addressId"> address id of the camera </param>
        /// <returns> false if fail search check, otherwise true </returns>
        private bool InputDetailsNotFoundCheck(int? addressId)
        {
            if(addressId != null)
            {
                using (var context = new DVLAEntities())
                {
                    if(context.Addresses.Find(addressId) == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Input the camera details to camera object 
        /// </summary>
        /// <param name="camera"> camera object for database </param>
        /// <param name="roadName"> road name of the camera  </param>
        /// <param name="roadNumber"> road number of the camera </param>
        /// <param name="longitude"> longitude of the camera </param>
        /// <param name="latitude"> latitude of the camera </param>
        /// <param name="addressId"> id of the camera address</param>
        /// <returns> the camera model for data base </returns>
        private EntityFrameWorkModel.Camera CameraDetailsInput(Camera camera,
            string roadName, string? roadNumber, decimal longitude, decimal latitude,
             int? addressId)
        {
            camera.RoadName = roadName;
            camera.RoadNumber = roadNumber;
            camera.Longitude = longitude;
            camera.Latitude = latitude;
            camera.AddressId = addressId;
            return camera;
        }
    }
}
