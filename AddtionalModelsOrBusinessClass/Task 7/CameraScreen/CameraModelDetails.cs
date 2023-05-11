/*==============================================================================
 *
 * Camera Details Class
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AddtionalModelsOrBusinessClass.Data;
using EntityFrameWorkModel;
using Newtonsoft.Json;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;

namespace AddtionalModelsOrBusinessClass.Task_7.CameraScreen
{
    public class CameraModelDetails
    {
        public int CameraId { get; set; }
        public string RoadName { get; set; }
        public string RoadNumber { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string CameraType { get; set; }
        public int? CameraTypeValue { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        private string _BaseURL = "https://localhost:7119/";

        /// <summary>
        /// Display Camera Detail screen
        /// </summary>
        /// <param name="displayList"> the click detial to display </param>
        /// <returns> the details for camera details screen </returns>
        public async Task<CameraModelDetails> CameraDetailsToDisplayAsync(CameraSearchDisplayList displayList)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var cameraModelDetails = new CameraModelDetails();
            int addressId;
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/cameras?longitudeFrom={displayList.Longitude}&longitudeTo={displayList.Longitude}" +
                $"&latitudeFrom={displayList.Latitude}&latitudeTo={displayList.Latitude}&pageNumber=1&itemPerPage=5"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<CameraList>(responseString);
                    cameraModelDetails.CameraId = responseObject.Cameras[0].CameraId;
                    cameraModelDetails.RoadName = responseObject.Cameras[0].RoadName;
                    if (responseObject.Cameras[0].RoadNumber != null)
                    {
                        cameraModelDetails.RoadNumber = responseObject.Cameras[0].RoadNumber;
                    }
                    cameraModelDetails.Longitude = responseObject.Cameras[0].Longitude;
                    cameraModelDetails.Latitude = responseObject.Cameras[0].Latitude;
                    cameraModelDetails.CameraType = responseObject.Cameras[0].CameraType;
                    if (responseObject.Cameras[0].CameraTypeLimitValue != null)
                    {
                        cameraModelDetails.CameraTypeValue = responseObject.Cameras[0].CameraTypeLimitValue;
                    }
                    if (responseObject.Cameras[0].AddressId != null)
                    {
                        addressId = (int)responseObject.Cameras[0].AddressId;
                        using (HttpResponseMessage response2 = await client.GetAsync($"https://localhost:7119/api/v1/addresses/{addressId}"))
                        {
                            if (response2.IsSuccessStatusCode)
                            {
                                var response2String = await response2.Content.ReadAsStringAsync();
                                var response2Object = JsonConvert.DeserializeObject<Addresses>(response2String);
                                cameraModelDetails.Line1 = response2Object.Line1;
                                cameraModelDetails.Line2 = response2Object.Line2;
                                cameraModelDetails.Line3 = response2Object.Line3;
                                cameraModelDetails.City = response2Object.City;
                                cameraModelDetails.County = response2Object.County;
                                cameraModelDetails.Country = response2Object.Country;
                                cameraModelDetails.PostCode = response2Object.PostalCode;
                                return cameraModelDetails;
                            }
                            throw new Exception("Address Get API does not work.");
                        }
                    }
                    else
                    {
                        return cameraModelDetails;
                    }
                }
                throw new Exception("Owner Get API does not work.");
            }
        }
        /// <summary>
        /// Save Camera Details on the screen 
        /// </summary>
        /// <param name="input"> boolean check new camera (true) or update camera(false) </param>
        /// <param name="roadName"> Road Name input </param>
        /// <param name="roadNumber"> Road Number input </param>
        /// <param name="longitudeString"> longitude input </param>
        /// <param name="latitudeString"> latitude input </param>
        /// <param name="cameraType"> the details of camera type
        /// either seconds after red light threshold or speed limit </param>
        /// <param name="addressEdit"> boolean of address edit checkbox </param>
        /// <param name="line1"> line1 of address</param>
        /// <param name="line2"> line2 of address </param> 
        /// <param name="line3"> line3 of address </param>
        /// <param name="city"> city of address </param>
        /// <param name="county"> county of address </param>
        /// <param name="country"> country of address </param>
        /// <param name="postcode"> postcode of address </param>
        /// <param name="cameraId"> cameraId to be save for update </param>
        /// <param name="cameraTypeString"> camera type of the camera </param>
        /// <returns> integer 1 for success save, -1 for non exisiting address </returns>
        public async Task<int> SaveCameraDetailsAsync(bool input, string roadName, string roadNumber,
            string longitudeString, string latitudeString, string cameraType, bool addressEdit,
            string line1, string line2, string line3, string city, string county,
            string country, string postcode, int cameraId, string cameraTypeString)
        {
            int cameraTypeValue = 0;
            decimal longitude = decimal.Parse(longitudeString);
            decimal latitude = decimal.Parse(latitudeString);
            string cameraSpecificType;
            int addressId = -1;
            if(addressEdit == true)
            {
                addressId = await GetAddressIdAsync(line1, line2,
                line3, city, county, country, postcode);
                if (addressId == -1)
                {
                    return -1;
                }
            }
            if (cameraTypeString == "Speed Limit (mph):")
            {
                cameraSpecificType = "Speed Camera";
                cameraTypeValue = int.Parse(cameraType);
            }
            else if (cameraTypeString == "Seconds After Red \n Light Threshold:")
            {
                cameraSpecificType = "Traffic Light Camera";
                cameraTypeValue = int.Parse(cameraType);
            }
            else
            {
                cameraSpecificType = "ANPR";
            }
            if (input == false)
            {
                var requestBody = new CameraPutInput
                {
                    CameraId = cameraId,
                    RoadName = roadName,
                    RoadNumber = roadNumber,
                    Longitude = longitude,
                    Latitude = latitude,
                    AddressId = addressId,
                    CameraType = cameraSpecificType,
                    CameraLimitValue = (byte)cameraTypeValue
                };
                if (addressEdit == false)
                {
                    requestBody.AddressId = null;
                }
                if (cameraSpecificType == "ANPR")
                {
                    requestBody.CameraLimitValue = null;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PutAsync($"https://localhost:7119/api/v1/cameras/{cameraId}", requestContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new Exception("Put Camera API does not work.");
                    }
                }
            }
            else
            {
                var requestBody = new CameraPostInput
                {
                    RoadName = roadName,
                    RoadNumber = roadNumber,
                    Longitude = longitude,
                    Latitude = latitude,
                    AddressId = addressId,
                    CameraType = cameraSpecificType,
                    CameraLimitValue = (byte)cameraTypeValue
                };
                if (addressEdit == false)
                {
                    requestBody.AddressId = null;
                }
                if (cameraSpecificType == "ANPR")
                {
                    requestBody.CameraLimitValue = null;
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync($"https://localhost:7119/api/v1/cameras", requestContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new Exception("Post Camera API does not work.");
                    }
                }
            }
        }
        /// <summary>
        /// get the address Id to be save 
        /// </summary>
        /// <param name="line1"> line1 of address</param>
        /// <param name="line2"> line2 of address </param> 
        /// <param name="line3"> line3 of address </param>
        /// <param name="city"> city of address </param>
        /// <param name="county"> county of address </param>
        /// <param name="country"> country of address </param>
        /// <param name="postcode"> postcode of address </param>
        /// <returns> address Id, or -1 if fail to found address id </returns>
        private async Task<int> GetAddressIdAsync(string line1, string line2,
            string line3, string city, string county,
            string country, string postcode)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.GetAsync(
                $"https://localhost:7119/api/v1/addresses?line1={line1}&line2={line2}" +
                $"&line3={line3}&city={city}&county={county}&country={country}&postalCode={postcode}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(responseString);
                }
                return -1;
            }
        }
    }
}
