/*==============================================================================
 *
 * Car Controller for Car related API
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

namespace WebAPI.Controllers
{
    /// <summary>
    /// Car Controller class that contain all api control for cars.
    /// </summary>
    [Route("api/v1/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        /// <summary>
        /// get the car detail of the specific car Id
        /// </summary>
        /// <param name="id">car id of the car </param>
        /// <returns> the car details with corresponding car id </returns>
        //GET: api/v1/cars/{CarId}
        [HttpGet("{id}")]
        public ActionResult<Cars> GetCar(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var car = context.Cars.Find(id);

                if (car == null)
                {
                    return NotFound();
                }

                return CarToCarAPIModel(car);
            }
        }
        /// <summary>
        /// GET API that get the car that matches the search filter in data base 
        /// </summary>
        /// <param name="registrationNumber"> registration number of the car </param>
        /// <param name="make"> make of the car </param>
        /// <param name="model"> model of the car </param>
        /// <param name="firstName"> first name of the car owner </param>
        /// <param name="lastName"> last name of the car owner </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> list of car that match the search filter, 
        /// if fail validation return error code </returns>
        // GET: api/v1/cars
        [HttpGet]
        public ActionResult<CarList> GetCar(
            string? registrationNumber, string? make, string? model,
            string? firstName, string? lastName, int pageNumber = 1, int itemPerPage = 5)
        {
            if (!CarSearchCheck(registrationNumber, make, model, firstName, lastName))
            {
                return UnprocessableEntity();
            }
            if (!PaginationCheck(pageNumber, itemPerPage))
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                IQueryable<EntityFrameWorkModel.Car> cars = context.Cars;
                if (!String.IsNullOrWhiteSpace(registrationNumber))
                {
                    cars = cars.Where(c => c.RegistrationNumber == registrationNumber);
                }
                if (!String.IsNullOrWhiteSpace(make))
                {
                    cars = cars.Where(c => c.Model.Make.Name == make);
                }
                if (!String.IsNullOrWhiteSpace(model))
                {
                    cars = cars.Where(c => c.Model.Name == model);
                }
                if (!String.IsNullOrWhiteSpace(firstName))
                {
                    cars = cars.Where(c => c.Owner.FirstName == firstName);
                }
                if (!String.IsNullOrWhiteSpace(lastName))
                {
                    cars = cars.Where(c => c.Owner.LastName == lastName);
                }
                int totalAvailableItem = cars.Count();
                var carsList = cars.OrderBy(x => x.CarId).Skip((pageNumber - 1) * itemPerPage).Take(itemPerPage).ToList();
                List<Models.Cars> carModels = new List<Models.Cars>();
                foreach (var car in carsList)
                {
                    carModels.Add(CarToCarAPIModel(car));
                }
                var returnList = new CarList();
                returnList.Car = carModels;
                returnList.TotalAvailabeItem = totalAvailableItem;
                return returnList;
            }
        }
        /// <summary>
        /// Get the sightings for a speicif car id
        /// </summary>
        /// <param name="id"> car id </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> a list of sightings for that specific car id </returns>
        //GET: api/v1/cars/{CarId}/Sightings
        [HttpGet("{id}/sightings")]
        public ActionResult<SightingsList> GetCarSightings(int? id, int pageNumber = 1, int itemPerPage = 5)
        {
            if (id == null || id <= 0 || !PaginationCheck(pageNumber, itemPerPage))
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                if (context.Cars.Find(id) == null)
                {
                    return NotFound();
                }
                var sightings = context.Sightings.Where(s => s.CarId == id);
                var totalAvailableItem = sightings.Count();
                var sightingsList = sightings.OrderBy(x => x.SightingId).Skip((pageNumber - 1) * itemPerPage).Take(itemPerPage).ToList();
                var sightingsModelList = new List<Sightings>();
                foreach (var s in sightingsList)
                {
                    sightingsModelList.Add(SightingToSightingsAPIModel(s));
                }
                var returnSightings = new SightingsList
                {
                    Sightings = sightingsModelList,
                    TotalAvailabeItem = totalAvailableItem
                };
                return returnSightings;
            }
        }
        /// <summary>
        /// Update the Car Details in database
        /// </summary>
        /// <param name="input"> Car put Input Model </param>
        /// <returns> return the get api of the updated car along with the car details </returns>
        //PUT: api/CarAPIModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Cars> PutCar(CarPutInput input)
        {
            if (!InputDetailsBadRequestCheck(true, input.CarId, input.RegistrationNumber!, input.ModelId, input.ColourId, input.OwnerId, input.RegistrationDate))
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(true, input.RegistrationNumber!, input.RegistrationDate))
            {
                return UnprocessableEntity();
            }
            if (!InputDetailsNotFoundCheck(input.ModelId, input.ColourId, input.OwnerId))
            {
                return NotFound();
            }
            using (var context = new DVLAEntities())
            {
                var car = context.Cars.Find(input.CarId);
                if (car == null)
                {
                    return NotFound();
                }
                car = CarDetailsInput(car, input.RegistrationNumber!, input.ModelId, input.ColourId, input.OwnerId, input.RegistrationDate);
                context.SaveChanges();

                return GetCar(input.CarId);
            }
        }

        /// <summary>
        /// Post API action to add car to the database 
        /// </summary>
        /// <param name="input"> Car post Input Model </param>
        /// <returns> get API with the new car id just add to database </returns>
        // POST: api/CarAPIModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Cars> PostCar(CarPostInput input)
        {
            if (!InputDetailsBadRequestCheck(false, 1, input.RegistrationNumber!, input.ModelId, input.ColourId, input.OwnerId, input.RegistrationDate))
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(false, input.RegistrationNumber!, input.RegistrationDate))
            {
                return UnprocessableEntity();
            }
            if (!InputDetailsNotFoundCheck(input.ModelId, input.ColourId, input.OwnerId))
            {
                return NotFound();
            }
            Car car = new EntityFrameWorkModel.Car();
            using (var context = new DVLAEntities())
            {
                context.Cars.Add(car);
                car = CarDetailsInput(car, input.RegistrationNumber!, input.ModelId, input.ColourId, input.OwnerId, input.RegistrationDate);
                context.SaveChanges();

                return GetCar(car.CarId);
            }
        }
        /// <summary>
        /// Convert the car from database to the output format for API (CarModel)
        /// </summary>
        /// <param name="car"> the car from database </param>
        /// <returns> the Car details with CarModel </returns>
        private Cars CarToCarAPIModel(Car car)
        {
            var carModel = new WebAPI.Models.Cars();
            carModel.CarId = car.CarId;
            carModel.RegistrationNumber = car.RegistrationNumber;
            carModel.ColourId = car.ColourId;
            carModel.Colour = car.Colour.Name;
            carModel.ModelId = car.ModelId;
            carModel.Model = car.Model.Name;
            carModel.MakeId = car.Model.Make.MakeId;
            carModel.Make = car.Model.Make.Name;
            carModel.RegistrationDate = car.RegistrationDate;
            carModel.OwnerId = car.OwnerId;
            carModel.OwnerFirstName = car.Owner.FirstName;
            carModel.OwnerLastName = car.Owner.LastName;
            return carModel;
        }
        /// <summary>
        /// Perform parameters check for search input with the database specification
        /// </summary>
        /// <param name="registrationNumber"> registration number of the car </param>
        /// <param name="make"> make of the car </param>
        /// <param name="model"> model of the car </param>
        /// <param name="firstName"> first name of the car owner </param>
        /// <param name="lastName"> last name of the car owner </param>
        /// <returns> false if fail search check, otherwise true </returns>
        private bool CarSearchCheck(string? registrationNumber = null, string? make = null, string? model = null,
            string? firstName = null, string? lastName = null)
        {
            if(!String.IsNullOrWhiteSpace(registrationNumber))
            {
                if (registrationNumber.Length > 7)
                {
                    return false;
                }
            }
            if (!String.IsNullOrWhiteSpace(make))
            {
                if (make.Length > 50)
                {
                    return false;
                }
            }
            if (!String.IsNullOrWhiteSpace(model))
            {
                if(model.Length > 50)
                {
                    return false;
                }
            }
            if (!String.IsNullOrWhiteSpace(firstName))
            {
                if(firstName.Length > 40)
                {
                    return false;
                }
            }
            if (!String.IsNullOrWhiteSpace(lastName))
            {
                if(lastName.Length > 40)
                {
                    return false;
                }
            }
            return true;
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
        /// Input car details to th car model 
        /// </summary>
        /// /// <param name="car"> the car model to input </param>
        /// <param name="registrationNumber"> registration number of the car </param>
        /// <param name="modelId"> model id of the model of the car </param>
        /// <param name="colourId"> colour id of the colour of the car </param>
        /// <param name="ownerId"> owner id of the owner of the car </param>
        /// <param name="registrationDate"> registrationDate of the car </param>
        /// <returns> the car model with details input </returns>
        private EntityFrameWorkModel.Car CarDetailsInput(Car car, string registrationNumber,
            int modelId, int colourId, int ownerId, DateTime registrationDate)
        {
            car.RegistrationNumber = registrationNumber;
            car.ModelId = modelId;
            car.ColourId = colourId;
            car.OwnerId = ownerId;
            car.RegistrationDate = registrationDate;
            return car;
        }
        /// <summary>
        /// Check for Bad Request 400 error 
        /// </summary>
        /// <param name="isPutAPI"> is this a put api or not </param>
        /// <param name="carId"> id of the car </param>
        /// <param name="registrationNumber"> registration number of the car </param>
        /// <param name="modelId"> model id of the car </param>
        /// <param name="colourId"> colour id of the car </param>
        /// <param name="ownerId"> owner id of the car </param>
        /// <param name="registrationDate"> registration date of the car </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsBadRequestCheck(bool isPutAPI, int? carId, string registrationNumber,
            int? modelId, int? colourId, int? ownerId, DateTime? registrationDate)
        {
            if(isPutAPI && (carId == null || carId <= 0))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(registrationNumber))
            {
                return false;
            }
            if (modelId == null || modelId <= 0)
            {
                return false;
            }
            if (colourId == null || colourId <= 0)
            {
                return false;
            }
            if (ownerId == null || ownerId <= 0)
            {
                return false;
            }
            if(registrationDate == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check for 422 unprocessable entity error 
        /// </summary>
        /// <param name="isPutAPI"> is this a put api or not </param>
        /// <param name="registrationNumber"> registration number of the car </param>
        /// <param name="registrationDate"> registration date of the car</param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsUnprocessableCheck(bool isPutAPI, string registrationNumber, DateTime registrationDate)
        {
            if(registrationNumber.Length > 7)
            {
                return false;
            }
            if(registrationDate > DateTime.Today)
            {
                return false;
            }
            using (var context = new DVLAEntities())
            {
                var carCount = context.Cars.Where(x => x.RegistrationNumber == registrationNumber).Count();
                if ((!isPutAPI && carCount != 0)|| (isPutAPI && carCount > 1))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Check for 404 not found error 
        /// </summary>
        /// <param name="modelId"> model id of the car </param>
        /// <param name="colourId"> colour id of the car </param>
        /// <param name="ownerId"> owner id of the car </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsNotFoundCheck(int modelId, int colourId, int ownerId)
        {
            using(var context = new DVLAEntities())
            {
                if (context.Models.Find(modelId) == null)
                {
                    return false;
                }
                if (context.Colours.Find(colourId) == null)
                {
                    return false;
                }
                if (context.Owners.Find(ownerId) == null)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Convert from sightings entity framework model to api sightings model 
        /// </summary>
        /// <param name="sighting"> sightings details in entity framework model </param>
        /// <returns> sightings details in api model </returns>
        private Sightings SightingToSightingsAPIModel(Sighting sighting)
        {
            var sightingModel = new WebAPI.Models.Sightings
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
    }
}
