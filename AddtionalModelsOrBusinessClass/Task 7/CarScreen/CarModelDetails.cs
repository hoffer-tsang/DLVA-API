/*==============================================================================
 *
 * Car Model Class
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkModel;
using System.Net.Http;
using System.Net.Http.Headers;
using AddtionalModelsOrBusinessClass.Data;
using Newtonsoft.Json;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;

namespace AddtionalModelsOrBusinessClass.Task_7.CarScreen
{
    public class CarModelDetails
    {
        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public List<JsonFormatObject.Sightings> Sightings { get; set; }
        private string _BaseURL = "https://localhost:7119/";
        /// <summary>
        /// get the car details to be display in car details screen
        /// </summary>
        /// <param name="registrationNumber"> the registration number to be display </param>
        /// <returns> car details </returns>
        public async Task<CarModelDetails> CarDetailsToDisplayAsync(string registrationNumber)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var carModelDetails = new CarModelDetails();
            using (HttpResponseMessage response = await client.GetAsync($"https://localhost:7119/api/v1/cars?registrationNumber={registrationNumber}&pageNumber=1&itemPerPage=5"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CarList>(responseString);
                    carModelDetails.CarId = responseObject.Car[0].CarId;
                    carModelDetails.RegistrationNumber = responseObject.Car[0].RegistrationNumber;
                    carModelDetails.Model = responseObject.Car[0].Model;
                    carModelDetails.Make = responseObject.Car[0].Make;
                    carModelDetails.OwnerFirstName = responseObject.Car[0].OwnerFirstName;
                    carModelDetails.OwnerLastName = responseObject.Car[0].OwnerLastName;
                    carModelDetails.Colour = responseObject.Car[0].Colour;
                    carModelDetails.RegistrationDate = responseObject.Car[0].RegistrationDate;
                }
            }
            using (HttpResponseMessage response = await client.GetAsync($"https://localhost:7119/api/v1/cars/{carModelDetails.CarId}/sightings?pageNumber=1&itemPerPage=5"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<SightingsList>(responseString);
                    carModelDetails.Sightings = responseObject.Sightings;
                }
            }
            return carModelDetails;
        }
        /// <summary>
        /// save the new car detials or updated car details in database
        /// </summary>
        /// <param name="input"> input new car or update detials </param>
        /// <param name="registrationNumber"> registration number of car </param>
        /// <param name="model"> model of car </param>
        /// <param name="colour"> colour of car </param>
        /// <param name="registrationDate"> registration date of car </param>
        /// <param name="firstName"> first name of owner </param>
        /// <param name="lastName"> last name of owner </param>
        /// <param name="carId"> car ID if update car, if not -1 </param>
        /// <returns> 1 if owner is found, return -1 if owner does not exists </returns>
        public async Task<int> SaveCarDetailsAsync(bool input, string registrationNumber,
            string model, string colour, DateTime registrationDate, string firstName, string lastName, int carId)
        {
            int modelId = await GetModelIdAsync(model);
            int colourId = await GetColourIdAsync(colour);
            int ownerId = await GetOwnerIdAsync(firstName, lastName);
            if (ownerId == -1)
            {
                return -1;
            }
            if (input == false)
            {
                var requestBody = new CarPutInput
                {
                    CarId = carId,
                    ModelId = modelId,
                    ColourId = colourId,
                    RegistrationDate = registrationDate,
                    RegistrationNumber = registrationNumber,
                    OwnerId = ownerId
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PutAsync($"https://localhost:7119/api/v1/cars/{carId}", requestContent))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    catch
                    {
                        return -2;
                    }
                }
            }
            else
            {
                var requestBody = new CarPostInput
                {
                    ModelId = modelId,
                    ColourId = colourId,
                    RegistrationDate = registrationDate,
                    RegistrationNumber = registrationNumber,
                    OwnerId = ownerId
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync($"https://localhost:7119/api/v1/cars", requestContent))
                {
                    try
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    catch
                    {
                        return -2;
                    }
                }
            }
            return 1;
        }
        /// <summary>
        /// get the colour id from colour
        /// </summary>
        /// <param name="colour"> colour of car</param>
        /// <returns> colour id </returns>
        private async Task<int> GetColourIdAsync(string colour)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.GetAsync($"https://localhost:7119/api/v1/colours"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Colours>>(responseString);
                    foreach(var c in responseObject)
                    {
                        if(c.ColourName == colour)
                        {
                            return c.ColourId;
                        }
                    }
                }
                throw new Exception("ColourId not found");
            }
        }
        /// <summary>
        /// get model id form the model
        /// </summary>
        /// <param name="model"> model of car </param>
        /// <returns> model id </returns>
        private async Task<int> GetModelIdAsync(string model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.GetAsync($"https://localhost:7119/api/v1/models"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Models>>(responseString);
                    foreach (var m in responseObject)
                    {
                        if (m.ModelName == model)
                        {
                            return m.ModelId;
                        }
                    }
                }
                throw new Exception("ModelId not found");
            }
        }
        /// <summary>
        /// get owner id from first name and last name
        /// </summary>
        /// <param name="firstName"> first name of owner </param>
        /// <param name="lastName"> last name of owner </param>
        /// <returns> owner id </returns>
        private async Task<int> GetOwnerIdAsync(string firstName, string lastName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.GetAsync($"https://localhost:7119/api/v1/owners?pageNumber=1&itemPerPage=9999"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<OwnerList>(responseString);
                    foreach (var o in responseObject.Owners)
                    {
                        if (o.FirstName == firstName && o.LastName == lastName)
                        {
                            return o.OwnerId;
                        }
                    }
                }
                return -1;
            }
        }
    }
}
