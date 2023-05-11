/*==============================================================================
 *
 * Car Search Display List Class
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/
using System;
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

namespace AddtionalModelsOrBusinessClass.Task_7.CarScreen
{
    public class CarSearchDisplayList
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }

        public string Make { get; set; }
        public string Owner { get; set; }

        private int _PageSize = 5;
        private string _BaseURL = "https://localhost:7119/";

        /// <summary>
        /// Perform the Search in database based on search field to update car list
        /// </summary>
        /// <param name="registrationNumberSearch"> registration number to search </param>
        /// <param name="modelSearch"> model to search </param>
        /// <param name="makeSearch"> make to search </param>
        /// <param name="firstNameSearch"> firstname to search </param>
        /// <param name="lastNameSearch"> lastname to search </param>
        /// <param name="pageNumber"> page number to be display </param>
        /// <param name="columnIndex"> column Index to be sorted </param>
        /// <returns> A list of car base on search field to display </returns>
        public async Task<List<CarSearchDisplayList>> SearchCarListAsync(
        string registrationNumberSearch,
        object modelSearch,
        object makeSearch,
        string firstNameSearch,
        string lastNameSearch,
        int pageNumber,
        int columnIndex)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<CarSearchDisplayList> carDisplayList = new List<CarSearchDisplayList>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/cars?registrationNumber={registrationNumberSearch}" +
                $"&make={makeSearch}&model={modelSearch}&firstName={firstNameSearch}&lastName={lastNameSearch}" +
                $"&pageNumber={pageNumber}&itemPerPage={_PageSize}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CarList>(responseString);
                    foreach (var ca in responseObject.Car)
                    {
                        var carDisplay = new CarSearchDisplayList
                        {
                            RegistrationNumber = ca.RegistrationNumber,
                            Model = ca.Model,
                            Make = ca.Make,
                            Owner = ca.OwnerFirstName + " " + ca.OwnerLastName,
                        };
                        carDisplayList.Add(carDisplay);
                    }
                    switch (columnIndex)
                    {
                        case 0:
                            carDisplayList.Sort(new CarRegistrationNumberComp());
                            break;
                        case 1:
                            carDisplayList.Sort(new CarModelComp());
                            break;
                        case 2:
                            carDisplayList.Sort(new CarMakeComp());
                            break;
                        case 3:
                            carDisplayList.Sort(new CarOwnerComp());
                            break;
                    }
                    return carDisplayList;
                }
                throw new Exception("GetCar API does not work.");
            }
        }
        /// <summary>
        /// Get total page number required for car display list 
        /// </summary>
        /// <param name="registrationNumberSearch"> registration number to search </param>
        /// <param name="modelSearch"> model to search </param>
        /// <param name="makeSearch"> make to search </param>
        /// <param name="firstNameSearch"> firstname to search </param>
        /// <param name="lastNameSearch"> lastname to search </param>>
        /// <returns> list of page number </returns>
        public async Task<List<int>> TotalCarPageNumberAsync(string registrationNumberSearch,
        object modelSearch,
        object makeSearch,
        string firstNameSearch,
        string lastNameSearch)
        {
            int totalPageNumber;
            List<int> pageNumberList = new List<int>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<CarSearchDisplayList> carDisplayList = new List<CarSearchDisplayList>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/cars?registrationNumber={registrationNumberSearch}" +
                $"&make={makeSearch}&model={modelSearch}&firstName={firstNameSearch}&lastName={lastNameSearch}" +
                $"&pageNumber=1&itemPerPage={_PageSize}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CarList>(responseString);
                    if ((responseObject.TotalAvailabeItem / _PageSize) == 0)
                    {
                        pageNumberList.Add(1);
                        return pageNumberList;
                    }
                    else
                    {
                        int leftover = responseObject.TotalAvailabeItem % _PageSize;
                        totalPageNumber = responseObject.TotalAvailabeItem / _PageSize;
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
