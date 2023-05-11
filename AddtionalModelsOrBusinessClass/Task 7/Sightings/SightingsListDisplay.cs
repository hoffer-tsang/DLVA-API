/*==============================================================================
 *
 * Sightings Display List Class
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
using System.Text;
using System.Threading.Tasks;
using AddtionalModelsOrBusinessClass.Task_7.Comparer;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;
using EntityFrameWorkModel;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace AddtionalModelsOrBusinessClass.Task_7.Sightings
{
    public class SightingsListDisplay
    {
        public DateTime SightingTime { get; set; }
        public int SecondsAfterRedLight { get; set; }
        public int Speed { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DatePaid { get; set; }
        private int _PageSize = 5;
        private string _BaseURL = "https://localhost:7119/";
        /// <summary>
        /// get the list of sighting for corresponding carid or camera id
        /// </summary>
        /// <param name="id"> car id or camera id </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="isCarScreen"> true for car id, false for camera id </param>
        /// <param name="columnIndex"> column to be sorted </param>
        /// <returns> a list of sightings to be display </returns>
        public async Task<List<SightingsListDisplay>> GetSightingsListAsync(int id, int pageNumber, bool isCarScreen, int columnIndex)
        {
            if (isCarScreen == true)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                List<SightingsListDisplay> sightingList = new List<SightingsListDisplay>();
                using (HttpResponseMessage response = await client.GetAsync(
                    $"https://localhost:7119/api/v1/cars/{id}/sightings?" +
                    $"pageNumber={pageNumber}&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<SightingsList>(responseString);
                        foreach (var s in responseObject.Sightings)
                        {
                            var sighting = new SightingsListDisplay
                            {
                                SightingTime = s.SightingTime
                            };
                            if (s.SecondsAfterRedLight != null)
                            {
                                sighting.SecondsAfterRedLight = (int)s.SecondsAfterRedLight;
                            }
                            if (s.SpeedMph != null)
                            {
                                sighting.Speed = (int)s.SpeedMph;
                            }
                            if (s.DateIssued != null)
                            {
                                sighting.DateIssued = (DateTime)s.DateIssued;
                            }
                            if (s.DatePaid != null)
                            {
                                sighting.DatePaid = (DateTime)s.DatePaid;
                            }
                            sightingList.Add(sighting);
                        }
                        switch (columnIndex)
                        {
                            case 0:
                                sightingList.Sort(new SightingSightingTimeComp());
                                break;
                            case 1:
                                sightingList.Sort(new SightingSecondsComp());
                                break;
                            case 2:
                                sightingList.Sort(new SightingSpeedComp());
                                break;
                            case 3:
                                sightingList.Sort(new SightingDateIssuedComp());
                                break;
                            case 4:
                                sightingList.Sort(new SightingDatePaidComp());
                                break;
                        }
                        return sightingList;
                    }
                    throw new Exception("Car Sighting API does not work.");
                }
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                List<SightingsListDisplay> sightingList = new List<SightingsListDisplay>();
                using (HttpResponseMessage response = await client.GetAsync(
                    $"https://localhost:7119/api/v1/cameras/{id}/sightings?" +
                    $"pageNumber={pageNumber}&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<SightingsList>(responseString);
                        foreach (var s in responseObject.Sightings)
                        {
                            var sighting = new SightingsListDisplay
                            {
                                SightingTime = s.SightingTime
                            };
                            if (s.SecondsAfterRedLight != null)
                            {
                                sighting.SecondsAfterRedLight = (int)s.SecondsAfterRedLight;
                            }
                            if (s.SpeedMph != null)
                            {
                                sighting.Speed = (int)s.SpeedMph;
                            }
                            if (s.DateIssued != null)
                            {
                                sighting.DateIssued = (DateTime)s.DateIssued;
                            }
                            if (s.DatePaid != null)
                            {
                                sighting.DatePaid = (DateTime)s.DatePaid;
                            }
                            sightingList.Add(sighting);
                        }
                        switch (columnIndex)
                        {
                            case 0:
                                sightingList.Sort(new SightingSightingTimeComp());
                                break;
                            case 1:
                                sightingList.Sort(new SightingSecondsComp());
                                break;
                            case 2:
                                sightingList.Sort(new SightingSpeedComp());
                                break;
                            case 3:
                                sightingList.Sort(new SightingDateIssuedComp());
                                break;
                            case 4:
                                sightingList.Sort(new SightingDatePaidComp());
                                break;
                        }
                        return sightingList;
                    }
                    throw new Exception("Camera Sighting API does not work.");
                }
            }
        }
        /// <summary>
        /// the total number of page for sightings
        /// </summary>
        /// <param name="id"> car id or camera id </param>
        /// <param name="isCarScreen"> true for car id, false for camera id </param>
        /// <returns> list of page number </returns>
        public async Task<List<int>> TotalSightingsPageNumberAsync(int id, bool isCarScreen)
        {
            if(isCarScreen == true)
            {
                int totalPageNumber;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                List<SightingsListDisplay> sightingList = new List<SightingsListDisplay>();
                using (HttpResponseMessage response = await client.GetAsync(
                    $"https://localhost:7119/api/v1/cars/{id}/sightings?" +
                    $"pageNumber=1&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<SightingsList>(responseString);
                        totalPageNumber = responseObject.TotalAvailabeItem;
                        List<int> pageNumberList = new List<int>();
                        if (totalPageNumber == 0)
                        {
                            pageNumberList.Add(1);
                            return pageNumberList;
                        }
                        else
                        {
                            int leftover = totalPageNumber % _PageSize;
                            totalPageNumber = (totalPageNumber / _PageSize);
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
                    throw new Exception("Car Sighting API does not work.");
                }
            }
            else
            {
                int totalPageNumber;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                List<SightingsListDisplay> sightingList = new List<SightingsListDisplay>();
                using (HttpResponseMessage response = await client.GetAsync(
                    $"https://localhost:7119/api/v1/cameras/{id}/sightings?" +
                    $"pageNumber=1&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<SightingsList>(responseString);
                        totalPageNumber = responseObject.TotalAvailabeItem;
                        List<int> pageNumberList = new List<int>();
                        if (totalPageNumber == 0)
                        {
                            pageNumberList.Add(1);
                            return pageNumberList;
                        }
                        else
                        {
                            int leftover = totalPageNumber % _PageSize;
                            totalPageNumber = (totalPageNumber / _PageSize);
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
                    throw new Exception("Camera Sighting API does not work.");
                }
            }
        }
    }
}
