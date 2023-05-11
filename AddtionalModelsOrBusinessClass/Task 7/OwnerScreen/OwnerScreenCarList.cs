/*==============================================================================
 *
 * Owner Screen Car Search Display List Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkModel;
using Newtonsoft.Json;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;
using AddtionalModelsOrBusinessClass.Task_7.Comparer;

namespace AddtionalModelsOrBusinessClass.Task_7.OwnerScreen
{
    public class OwnerScreenCarList
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }

        public string Make { get; set; }
        public string Colour { get; set; }
        private int _PageSize = 5;
        private string _BaseURL = "https://localhost:7119/";
        /// <summary>
        /// Get Car List for specific owner 
        /// </summary>
        /// <param name="ownerId"> ownerId of the owner </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="columnIndex"> column Index to be sorted </param>
        /// <returns> list of car to display in that page </returns>
        public async Task<List<OwnerScreenCarList>> GetCarListAsync(int ownerId, int pageNumber, int columnIndex)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<OwnerScreenCarList> ownerScreenCarList = new List<OwnerScreenCarList>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/owners/{ownerId}/cars?pageNumber={pageNumber}&itemPerPage={_PageSize}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CarList>(responseString);
                    foreach (var ca in responseObject.Car)
                    {
                        var carDisplay = new OwnerScreenCarList
                        {
                            RegistrationNumber = ca.RegistrationNumber,
                            Model = ca.Model,
                            Make = ca.Make,
                            Colour = ca.Colour
                        };
                        ownerScreenCarList.Add(carDisplay);
                    }
                    switch (columnIndex)
                    {
                        case 0:
                            ownerScreenCarList.Sort(new CarDetailsRegistrationNumberComp());
                            break;
                        case 1:
                            ownerScreenCarList.Sort(new CarDetailsModelComp());
                            break;
                        case 2:
                            ownerScreenCarList.Sort(new CarDetailsMakeComp());
                            break;
                        case 3:
                            ownerScreenCarList.Sort(new CarDetailsColourComp());
                            break;
                    }
                    return ownerScreenCarList;
                }
                throw new Exception("GetCar API does not work.");
            }
        }/// <summary>
        /// find the total page number to display
        /// </summary>
        /// <param name="ownerId"> owernid of the owner</param>
        /// <returns> a list of page number </returns>
        public async Task<List<int>> TotalCarPageNumberAsync(int ownerId)
        {
            int totalPageNumber;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<OwnerScreenCarList> ownerScreenCarList = new List<OwnerScreenCarList>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/owners/{ownerId}/cars?pageNumber=1&itemPerPage=5"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CarList>(responseString);
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
                throw new Exception("GetCar API does not work.");
            }
        }
    }
}
