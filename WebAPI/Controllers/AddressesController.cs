/*==============================================================================
 *
 * Address Controller for Address related API
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
    /// Address Controller class that contain all api control for address.
    /// </summary>
    [Route("api/v1/addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        /// <summary>
        /// get the address detail of the specific address Id
        /// </summary>
        /// <param name="id"> address id of the address </param>
        /// <returns> the address details with corresponding address id </returns>
        //GET: api/v1/cars/{CarId}
        [HttpGet("{id}")]
        public ActionResult<Addresses> GetAddress(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var address = context.Addresses.Find(id);

                if (address == null)
                {
                    return NotFound();
                }

                return AddressToAddressModel(address);
            }
        }
        /// <summary>
        /// Get the addressId of the address entered 
        /// </summary>
        /// <param name="line1"> line 1 of address </param>
        /// <param name="line2"> line 2 of address </param>
        /// <param name="line3"> line 3 of address </param>
        /// <param name="city"> city of address </param>
        /// <param name="county"> county of address </param>
        /// <param name="country"> country of address </param>
        /// <param name="postalCode"> psot code of address </param>
        /// <returns> address id of the address </returns>
        [HttpGet]
        public ActionResult<int> GetAddress(string line1, string? line2,
            string? line3, string city, string county, string country, string postalCode)
        {
            if (line1 == null || city == null || county == null || country == null || postalCode == null )
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(line1, line2!, line3!, city, county, country, postalCode))
            {
                return UnprocessableEntity();
            }
            using (var context = new DVLAEntities())
            {
                var address = context.Addresses.Where(x => x.Line1 == line1);
                address = address.Where(x => x.City == city);
                address = address.Where(x => x.County == county);
                address = address.Where(x => x.Country == country);
                address = address.Where(x => x.PostalCode == postalCode);
                if (!String.IsNullOrWhiteSpace(line2))
                {
                    address = address.Where(x => x.Line2 == line2);
                }
                if (!String.IsNullOrWhiteSpace(line3))
                {
                    address = address.Where(x => x.Line3 == line3);
                }
                if (address == null || address.Count() == 0)
                {
                    return NotFound();
                }
                return int.Parse(address.Select(x => x.AddressId).FirstOrDefault().ToString());
            }
        }
        /// <summary>
        /// Check address input for unprocessable error 
        /// </summary>
        /// <param name="line1"> line 1 of address </param>
        /// <param name="line2"> line 2 of address </param>
        /// <param name="line3"> line 3 of address </param>
        /// <param name="city"> city of address </param>
        /// <param name="county"> county of address </param>
        /// <param name="country"> country of address </param>
        /// <param name="postalCode"> psot code of address </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsUnprocessableCheck(string line1, string? line2,
            string? line3, string city, string county, string country, string postalCode)
        {
            if (line1.Length > 100)
            {
                return false;
            }
            if (!String.IsNullOrWhiteSpace(line2))
            {
                if(line2.Length > 100)
                {
                    return false;
                }
            }
            if (!String.IsNullOrWhiteSpace(line3))
            {
                if (line3.Length > 100)
                {
                    return false;
                }
            }
            if (city.Length > 50 || county.Length > 50 || country.Length > 50)
            {
                return false;
            }
            if (postalCode.Length > 16)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Convert address from database to the output format for API AddressModel
        /// </summary>
        /// <param name="address"> the address from database </param>
        /// <returns> the address details with the address model </returns>
        private Addresses AddressToAddressModel(Address address)
        {
            return new Addresses
            {
                AddressId = address.AddressId,
                Line1 = address.Line1,
                Line2 = address.Line2,
                Line3 = address.Line3,
                City = address.City,
                County = address.County,
                Country = address.Country,
                PostalCode = address.PostalCode
            };
        }
    }
}
