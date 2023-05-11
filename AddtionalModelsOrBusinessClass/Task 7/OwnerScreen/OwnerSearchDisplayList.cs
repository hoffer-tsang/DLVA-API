/*==============================================================================
 *
 * Owner Search Display List Class
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
using System.Text;
using System.Threading.Tasks;
using AddtionalModelsOrBusinessClass.Task_7.Comparer;
using AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject;
using EntityFrameWorkModel;
using Newtonsoft.Json;

namespace AddtionalModelsOrBusinessClass.Task_7.OwnerScreen
{
    public class OwnerSearchDisplayList
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        private int _PageSize = 5;
        private string _BaseURL = "https://localhost:7119/";

        /// <summary>
        /// Perform the Search in database based on search field to update Owner list
        /// </summary>
        /// <param name="firstNameSearch"> firstname to search </param>
        /// <param name="lastNameSearch"> lastname to search </param>
        /// <param name="dateOfBirthIncluded"> checkbox status for date of birth </param>
        /// <param name="dateOfBirthSearch"> date of birth to search  </param>
        /// <param name="pageNumber"> page number to be display </param>
        /// <param name="columnIndex"> column Index to be sorted </param>
        /// <returns> A list of owner base on search field to display </returns>
        public async Task<List<OwnerSearchDisplayList>> SearchOwnerListAsync(
        string firstNameSearch,
        string lastNameSearch,
        bool dateOfBirthIncluded,
        DateTime dateOfBirthSearch,
        int pageNumber,
        int columnIndex)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            List<OwnerSearchDisplayList> ownerSearchDisplayList = new List<OwnerSearchDisplayList>();
            if (dateOfBirthIncluded)
            {
                using (HttpResponseMessage response = await client.GetAsync(
                                $"https://localhost:7119/api/v1/owners?firstName={firstNameSearch}" +
                                $"&lastName={lastNameSearch}&dateOfBirth={dateOfBirthSearch.ToString("yyyy-MM-dd")}&pageNumber={pageNumber}&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<OwnerList>(responseString);
                        foreach (var o in responseObject.Owners)
                        {
                            var ownerDisplay = new OwnerSearchDisplayList
                            {
                                FirstName = o.FirstName,
                                LastName = o.LastName,
                                DateOfBirth = o.DateOfBirth,
                                AddressLine1 = o.AddressLine1
                            };
                            ownerSearchDisplayList.Add(ownerDisplay);
                        }
                        switch (columnIndex)
                        {
                            case 0:
                                ownerSearchDisplayList.Sort(new OwnerFirstNameComp());
                                break;
                            case 1:
                                ownerSearchDisplayList.Sort(new OwnerLastNameComp());
                                break;
                            case 2:
                                ownerSearchDisplayList.Sort(new OwnerDOBComp());
                                break;
                            case 3:
                                ownerSearchDisplayList.Sort(new OwnerAddressComp());
                                break;
                        }
                        return ownerSearchDisplayList;
                    }
                    throw new Exception("GetOwner API does not work.");
                }
            }
            else
            {
                using (HttpResponseMessage response = await client.GetAsync(
                                $"https://localhost:7119/api/v1/owners?firstName={firstNameSearch}" +
                                $"&lastName={lastNameSearch}&pageNumber={pageNumber}&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<OwnerList>(responseString);
                        foreach (var o in responseObject.Owners)
                        {
                            var ownerDisplay = new OwnerSearchDisplayList
                            {
                                FirstName = o.FirstName,
                                LastName = o.LastName,
                                DateOfBirth = o.DateOfBirth,
                                AddressLine1 = o.AddressLine1
                            };
                            ownerSearchDisplayList.Add(ownerDisplay);
                        }
                        switch (columnIndex)
                        {
                            case 0:
                                ownerSearchDisplayList.Sort(new OwnerFirstNameComp());
                                break;
                            case 1:
                                ownerSearchDisplayList.Sort(new OwnerLastNameComp());
                                break;
                            case 2:
                                ownerSearchDisplayList.Sort(new OwnerDOBComp());
                                break;
                            case 3:
                                ownerSearchDisplayList.Sort(new OwnerAddressComp());
                                break;
                        }
                        return ownerSearchDisplayList;
                    }
                    throw new Exception("GetOwner API does not work.");
                }
            }
        }
        /// <summary>
        /// Find total page number required for owner list 
        /// </summary>
        /// <param name="firstNameSearch"> firstname to search </param>
        /// <param name="lastNameSearch"> lastname to search </param>
        /// <param name="dateOfBirthIncluded"> checkbox status for date of birth </param>
        /// <param name="dateOfBirthSearch"> date of birth to search  </param>
        /// <returns> A list of page number to display </returns>
        public async Task<List<int>> TotalOwnerPageNumberAsync(
        string firstNameSearch,
        string lastNameSearch,
        bool dateOfBirthIncluded,
        DateTime dateOfBirthSearch)
        {
            int totalPageNumber;
            List<int> pageNumberList = new List<int>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            if (dateOfBirthIncluded)
            {
                using (HttpResponseMessage response = await client.GetAsync(
                                $"https://localhost:7119/api/v1/owners?firstName={firstNameSearch}" +
                                $"&lastName={lastNameSearch}&dateOfBirth={dateOfBirthSearch.ToString("yyyy-MM-dd")}&pageNumber=1&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<OwnerList>(responseString);
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
                    throw new Exception("GetOwner API does not work.");
                }
            }
            else
            {
                using (HttpResponseMessage response = await client.GetAsync(
                                $"https://localhost:7119/api/v1/owners?firstName={firstNameSearch}" +
                                $"&lastName={lastNameSearch}&pageNumber=1&itemPerPage={_PageSize}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<OwnerList>(responseString);
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
                    throw new Exception("GetOwner API does not work.");
                }
            }
        }
    }
}
