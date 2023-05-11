/*==============================================================================
 *
 * Camera Search Display List Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AddtionalModelsOrBusinessClass.Task_7.Comparer;
using EntityFrameWorkModel;
using Newtonsoft.Json;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;

namespace AddtionalModelsOrBusinessClass.Task_7.CameraScreen
{
    public class CameraSearchDisplayList
    {
        public string CameraType { get; set; }

        public string RoadName { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        private int _PageSize = 5;
        private string _BaseURL = "https://localhost:7119/";
        /// <summary>
        /// Get the camera list based on search field (all null when page refresh)
        /// </summary>
        /// <param name="longitudeFrom"> longtitude from search field </param>
        /// <param name="longitudeTo"> longtitude to search field </param>
        /// <param name="latitudeFrom"> latitude from search field </param>
        /// <param name="latitudeTo"> latitude to search field </param>
        /// <param name="pageNumber"> page number to be display </param>
        /// <param name="columnIndex"> Index of column to be sorted </param>
        /// <returns> a list of filtered camera search display </returns>
        public async Task<List<CameraSearchDisplayList>> SearchCameraListAsync(
        string longitudeFrom, string longitudeTo,
        string latitudeFrom, string latitudeTo, int pageNumber, int columnIndex)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<CameraSearchDisplayList> cameraDisplayList = new List<CameraSearchDisplayList>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/cameras?longitudeFrom={longitudeFrom}" +
                $"&longitudeTo={longitudeTo}&latitudeFrom={latitudeFrom}&latitudeTo={latitudeTo}" +
                $"&pageNumber={pageNumber}&itemPerPage={_PageSize}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CameraList>(responseString);
                    foreach (var ca in responseObject.Cameras)
                    {
                        var cameraDisplay = new CameraSearchDisplayList
                        {
                            CameraType = ca.CameraType,
                            RoadName = ca.RoadName,
                            Longitude = ca.Longitude,
                            Latitude = ca.Latitude
                        };
                        cameraDisplayList.Add(cameraDisplay);
                    }
                    switch (columnIndex)
                    {
                        case 0:
                            cameraDisplayList.Sort(new CameraTypeComp());
                            break;
                        case 1:
                            cameraDisplayList.Sort(new CameraRoadNameComp());
                            break;
                        case 2:
                            cameraDisplayList.Sort(new CameraLongitudeComp());
                            break;
                        case 3:
                            cameraDisplayList.Sort(new CameraLatitudeComp());
                            break;
                    }
                    return cameraDisplayList;
                }
                throw new Exception("GetCar API does not work.");
            }
        }
        /// <summary>
        /// Find the total number of page number required 
        /// to be show in page selection drop box
        /// </summary>
        /// <param name="longitudeFrom"> longtitude from search field </param>
        /// <param name="longitudeTo"> longtitude to search field </param>
        /// <param name="latitudeFrom"> latitude from search field </param>
        /// <param name="latitudeTo"> latitude to search field </param>
        /// <returns> list of page number </returns>
        public async Task<List<int>> TotalCameraPageNumberAsync(string longitudeFrom, string longitudeTo,
        string latitudeFrom, string latitudeTo)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            int totalPageNumber;
            List<int> pageNumberList = new List<int>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/cameras?longitudeFrom={longitudeFrom}" +
                $"&longitudeTo={longitudeTo}&latitudeFrom={latitudeFrom}&latitudeTo={latitudeTo}" +
                $"&pageNumber=1&itemPerPage={_PageSize}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CameraList>(responseString);
                    if ((responseObject.TotalAvailabeItem / _PageSize) == 0)
                    {
                        pageNumberList.Add(1);
                        return pageNumberList;
                    }
                    else
                    {
                        int leftover = responseObject.TotalAvailabeItem % _PageSize;
                        totalPageNumber = (responseObject.TotalAvailabeItem / _PageSize);
                        if (leftover > 0)
                        {
                            totalPageNumber += 1;
                        }
                        for (int i = 0; i < totalPageNumber; i++)
                        {
                            pageNumberList.Add(i + 1);
                        }
                        return pageNumberList;
                    }
                }
                throw new Exception("GetCar API does not work.");
            }
        }
    }
}
