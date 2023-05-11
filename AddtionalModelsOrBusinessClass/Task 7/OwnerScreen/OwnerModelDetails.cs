/*==============================================================================
 *
 * Owner Details Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkModel;
using Newtonsoft.Json;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;
using AddtionalModelsOrBusinessClass.Data;
using System.Runtime.Remoting.Contexts;

namespace AddtionalModelsOrBusinessClass.Task_7.OwnerScreen
{
    public class OwnerModelDetails
    {
        public int OwnerId { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public byte[] RowVersion { get; set; }
        public ICollection<Car> CarList { get; set; }
        private string _BaseURL = "https://localhost:7119/";
        /// <summary>
        /// Display Owner Details in Owner Details Screen
        /// </summary>
        /// <param name="displayList"> the details in owner screen display list </param>
        /// <returns> the specifc owner model details </returns>
        public async Task<OwnerModelDetails> OwnerDetailsToDisplayAsync(OwnerSearchDisplayList displayList)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var ownerModelDetails = new OwnerModelDetails();
            int addressId;
            using (HttpResponseMessage response = await client.GetAsync($"https://localhost:7119/api/v1/owners" +
                $"?firstName={displayList.FirstName}&lastName={displayList.LastName}&dateOfBirth={displayList.DateOfBirth.ToString("yyyy-MM-dd")}&pageNumber=1&itemPerPage=5"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<OwnerList>(responseString);
                    ownerModelDetails.OwnerId = responseObject.Owners[0].OwnerId;
                    ownerModelDetails.DateOfBirth = responseObject.Owners[0].DateOfBirth;
                    ownerModelDetails.FirstName = responseObject.Owners[0].FirstName;
                    ownerModelDetails.LastName = responseObject.Owners[0].LastName;
                    ownerModelDetails.RowVersion = responseObject.Owners[0].RowVersion;
                    addressId = responseObject.Owners[0].AddressId;
                    using (HttpResponseMessage response2 = await client.GetAsync($"https://localhost:7119/api/v1/addresses/{addressId}"))
                    {
                        if (response2.IsSuccessStatusCode)
                        {
                            var response2String = await response2.Content.ReadAsStringAsync();
                            var response2Object = JsonConvert.DeserializeObject<Addresses>(response2String);
                            ownerModelDetails.Line1 = response2Object.Line1;
                            ownerModelDetails.Line2 = response2Object.Line2;
                            ownerModelDetails.Line3 = response2Object.Line3;
                            ownerModelDetails.City = response2Object.City;
                            ownerModelDetails.County = response2Object.County;
                            ownerModelDetails.Country = response2Object.Country;
                            ownerModelDetails.PostCode = response2Object.PostalCode;
                            return ownerModelDetails;
                        }
                        throw new Exception("Address Get API does not work.");
                    }
                }
                throw new Exception("Owner Get API does not work.");
            }
        }
        /// <summary>
        /// save the new car detials or updated car details in database
        /// </summary>
        /// <param name="input"> input new owner or update detials </param>
        /// <param name="dateOfBirth"> date of birth of owner </param>
        /// <param name="firstName"> first name of owner</param>
        /// <param name="lastName"> last name of owner</param>
        /// <param name="line1"> line1 of owner address </param>
        /// <param name="line2"> line2 of owner address </param>
        /// <param name="line3"> line3 of owner address </param>
        /// <param name="city"> city of owner address </param>
        /// <param name="county"> county of owner address </param>
        /// <param name="country"> country of owner address </param>
        /// <param name="postcode"> postcode of owner address </param>
        /// <param name="ownerId"> ownerId to be update in details </param>
        /// <param name="rowVersion"> the row version of the owner for concurrency check </param>
        /// <returns> return 1 if save success, or -1 for invalid address detials,
        /// or -2 for concurrency exceptions </returns>
        public async Task<int> SaveOwnerDetailsAsync(bool input, DateTime dateOfBirth,
            string firstName, string lastName, string line1, string line2,
            string line3, string city, string county,
            string country, string postcode, int ownerId, byte[] rowVersion)
        {
            int addressId = await GetAddressIdAsync(line1, line2,
            line3, city, county, country, postcode);
            if (addressId == -1)
            {
                return -1;
            }

            if (input == false)
            {
                var requestBody = new OwnerPutInput
                {
                    OwnerId = ownerId,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    AddressId = addressId,
                    RowVersion = rowVersion
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PutAsync($"https://localhost:7119/api/v1/owners/{ownerId}", requestContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return -2;
                    }
                    else
                    {
                        throw new Exception("Put Onwer API does not work.");
                    }
                }
            }
            else
            {
                var requestBody = new OwnerPutInput
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    AddressId = addressId
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync($"https://localhost:7119/api/v1/owners", requestContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new Exception("Post Onwer API does not work.");
                    }
                }
            }
        }
        /// <summary>
        /// Find the address Id from address details 
        /// </summary>
        /// <param name="line1"> line1 of owner address </param>
        /// <param name="line2"> line2 of owner address </param>
        /// <param name="line3"> line3 of owner address </param>
        /// <param name="city"> city of owner address </param>
        /// <param name="county"> county of owner address </param>
        /// <param name="country"> country of owner address </param>
        /// <param name="postcode"> postcode of owner address </param>
        /// <returns> address id, or -1 if fail to found address id </returns>
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
