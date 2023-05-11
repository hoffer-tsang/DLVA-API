/*==============================================================================
 *
 * Combo Box Class
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;
using AddtionalModelsOrBusinessClass.Task_7.Comparer;
using EntityFrameWorkModel;
using Newtonsoft.Json;
using AddtionalModelsOrBusinessClass.Data;

namespace AddtionalModelsOrBusinessClass.Task_7.CarScreen
{
    /// <summary>
    /// Generate Combo Box drop down option
    /// </summary>
    public class GenerateComboBoxOption
    {
        private string _BaseURL = "https://localhost:7119/";
        /// <summary>
        /// Get all model in database 
        /// </summary>
        /// <returns> a list of model </returns>
        public async Task<List<string>> AvaliableModelAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> modelList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/models"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Models>>(responseString);
                    foreach (var m in responseObject)
                    {
                        modelList.Add(m.ModelName);
                    }
                    return modelList;
                }
                throw new Exception("GetModel API does not work.");
            }
        }
        /// <summary>
        /// Get all Make in database
        /// </summary>
        /// <returns> a list of make </returns>
        public async Task<List<string>> AvaliableMakeAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> makeList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/make"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Makes>>(responseString);
                    foreach (var m in responseObject)
                    {
                        makeList.Add(m.MakeName);
                    }
                    return makeList;
                }
                throw new Exception("GetMake API does not work.");
            }
        }
        /// <summary>
        /// get all avaliable colour in database
        /// </summary>
        /// <returns> a list of colour </returns>
        public async Task<List<string>> AvaliableColourAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> colourList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/colours"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Colours>>(responseString);
                    foreach (var c in responseObject)
                    {
                        colourList.Add(c.ColourName);
                    }
                    return colourList;
                }
                throw new Exception("GetColour API does not work.");
            }
        }
        /// <summary>
        /// get the corresponing model value for make value for update
        /// </summary>
        /// <param name="make"> make value of car </param>
        /// <returns> model value of the make</returns>
        public async Task<List<string>> ModelValueUpdateAsync(string make)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            int makeId = -1;
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/make"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Makes>>(responseString);
                    foreach(var m in responseObject)
                    {
                        if(m.MakeName == make)
                        {
                            makeId = m.MakeId;
                        }
                    }
                    if(makeId == -1)
                    {
                        throw new Exception("Make Not Found.");
                    }
                }
                else
                {
                    throw new Exception("GetMakeId API does not work.");
                }
            }
            List<string> modelList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/make/{makeId}/models"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<List<Models>>(responseString);
                    foreach (var m in responseObject)
                    {
                        modelList.Add(m.ModelName);
                    }
                    return modelList;
                }
                throw new Exception("GetMakeModel API does not work.");
            }
        }
        /// <summary>
        /// Update the make List avaliable, after model is chosen
        /// </summary>
        /// <param name="model"> model chosen </param>
        /// <param name="isModelChanged"> is the model chosen </param>
        /// <returns> list of make of the model to display, 
        /// if model is not changed return null </returns>
        public async Task<List<string>> MakeValueUpdateAsync(string model, bool isModelChanged)
        {
            if(isModelChanged == true)
            {
                return null;
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                int modelId = -1;
                using (HttpResponseMessage response = await client.GetAsync(
                    $"https://localhost:7119/api/v1/models"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<List<Models>>(responseString);
                        foreach (var m in responseObject)
                        {
                            if (m.ModelName == model)
                            {
                                modelId = m.ModelId;
                            }
                        }
                        if (modelId == -1)
                        {
                            throw new Exception("Model Not Found.");
                        }
                    }
                    else
                    {
                        throw new Exception("GetModelId API does not work.");
                    }
                }
                List<string> makeList = new List<string>();
                using (HttpResponseMessage response = await client.GetAsync(
                    $"https://localhost:7119/api/v1/models/{modelId}/make"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<Makes>(responseString);
                        makeList.Add(responseObject.MakeName);
                        return makeList;
                    }
                    throw new Exception("GetModelMake API does not work.");
                }
            }
        }
    }
}
