/*==============================================================================
 *
 * Owner Controller for Owner related API
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
    /// Owner Controller class that contain all api control for Owner.
    /// </summary>
    [Route("api/v1/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        /// <summary>
        /// get the owner detail of the specific owner Id
        /// </summary>
        /// <param name="id">owner id of the owner </param>
        /// <returns> the owner details with corresponding owner id </returns>
        //GET: api/v1/owners/{id}
        [HttpGet("{id}")]
        public ActionResult<Owners> GetOwner(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var owner = context.Owners.Find(id);

                if (owner == null)
                {
                    return NotFound();
                }

                return OwnerToOwnerAPIModel(owner);
            }
        }

        /// <summary>
        /// GET API that get the car that matches the search filter in data base 
        /// </summary>
        /// <param name="id"> registration number of the car </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> list of car that match the search filter, 
        /// if fail validation return error code </returns>
        // GET: api/v1/cars
        [HttpGet("{id}/cars")]
        public ActionResult<CarList> GetOwnersCars(int? id, int pageNumber = 1, int itemPerPage = 5)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            if (!PaginationCheck(pageNumber, itemPerPage))
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var owner = context.Owners.Find(id);
                if(owner == null)
                {
                    return NotFound();
                }
                int totalAvailableItem = owner.Cars.Count();
                var carsList = owner.Cars.OrderBy(x => x.CarId).Skip((pageNumber - 1) * itemPerPage).Take(itemPerPage).ToList();
                List<Models.Cars> carModels = new List<Models.Cars>();
                foreach (var car in carsList)
                {
                    carModels.Add(CarToCarAPIModel(car));
                }
                var returnList = new CarList();
                returnList.Car = carModels;
                returnList.TotalAvailabeItem = totalAvailableItem;
                return returnList;
            }
        }
        /// <summary>
        /// Get the Address of the owner with owner id
        /// </summary>
        /// <param name="id"> the id of the owner </param>
        /// <returns> the address of the owner </returns>
        [HttpGet("{id}/Address")]
        public ActionResult<Addresses> GetOwnersAddresses(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                var owner = context.Owners.Find(id);
                if (owner == null)
                {
                    return NotFound();
                }
                var address = owner.Address;
                return AddressToAddressModel(address);
            }
        }
        /// <summary>
        /// Perform Owner Search with first name, last name and date of birth 
        /// </summary>
        /// <param name="firstName"> first name of owner to serach </param>
        /// <param name="lastName"> last name of owner to search </param>
        /// <param name="dateOfBirth"> date of birth of owner to search </param>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> a list of owner that matches the search filter </returns>
        [HttpGet]
        public ActionResult<OwnerList> GetOwner(string? firstName, string? lastName,
            DateTime? dateOfBirth, int pageNumber = 1, int itemPerPage = 5)
        {
            if (!OwnerSearchCheck(firstName, lastName, dateOfBirth))
            {
                return UnprocessableEntity();
            }
            if (!PaginationCheck(pageNumber, itemPerPage))
            {
                return BadRequest();
            }
            using (var context = new DVLAEntities())
            {
                IQueryable<EntityFrameWorkModel.Owner> owners = context.Owners;
                if (!String.IsNullOrWhiteSpace(firstName))
                {
                    owners = owners.Where(o => o.FirstName == firstName);
                }
                if (!String.IsNullOrWhiteSpace(lastName))
                {
                    owners = owners.Where(o => o.LastName == lastName);
                }
                if(dateOfBirth != null)
                {
                    dateOfBirth = DateTime.Parse(dateOfBirth.Value.ToString("yyyy-MM-dd"));
                    owners = owners.Where(o => o.DateOfBirth == dateOfBirth);
                }
                int totalAvailableItem = owners.Count();
                var ownersList = owners.OrderBy(x => x.OwnerId).Skip((pageNumber - 1) * itemPerPage).Take(itemPerPage).ToList();
                List<Models.Owners> ownerModels = new List<Models.Owners>();
                foreach (var owner in ownersList)
                {
                    ownerModels.Add(OwnerToOwnerAPIModel(owner));
                }
                var returnList = new OwnerList();
                returnList.Owners = ownerModels;
                returnList.TotalAvailabeItem = totalAvailableItem;
                return returnList;
            }
        }
        /// <summary>
        /// Update the Owner Details in database
        /// </summary>
        /// <param name="input"> inputModel for Owner Put API </param>
        /// <returns> return the get api of the updated owner along with the owner details </returns>
        //PUT: api/Owner APIModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Owners> PutOwner(OwnerPutInput input)
        {
            if (!InputDetailsBadRequestCheck(true, input.OwnerId,
                input.FirstName!, input.LastName!, input.DateOfBirth, input.AddressId, input.RowVersion))
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(input.FirstName!, input.LastName!, input.DateOfBirth))
            {
                return UnprocessableEntity();
            }
            if (!InputDetailsNotFoundCheck(input.AddressId))
            {
                return NotFound();
            }
            using (var context = new DVLAEntities())
            {
                var owner = context.Owners.Find(input.OwnerId);
                {
                    if (owner == null)
                    {
                        return NotFound();
                    }
                }
                if(!owner.RowVersion.SequenceEqual(input.RowVersion!))
                {
                    return Conflict();
                }
                owner = OwnerDetailsInput(
                    owner, input.FirstName!, input.LastName!, input.DateOfBirth, input.AddressId);
                context.SaveChanges();
                return GetOwner(owner.OwnerId);
            }
        }

        /// <summary>
        /// Post API action to add owner to the database 
        /// </summary>
        /// <param name="input"> inputModel for Owner Post API </param>
        /// <returns> get API with the new owner id just add to database </returns>
        // POST: api/OwnerAPIModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Owners> PostOwner(OwnerPostInput input)
        {
            if (!InputDetailsBadRequestCheck(false, 1, input.FirstName!, 
                input.LastName!, input.DateOfBirth, input.AddressId, null))
            {
                return BadRequest();
            }
            if (!InputDetailsUnprocessableCheck(
                input.FirstName!, input.LastName!, input.DateOfBirth))
            {
                return UnprocessableEntity();
            }
            if (!InputDetailsNotFoundCheck(input.AddressId))
            {
                return NotFound();
            }
            Owner owner = new EntityFrameWorkModel.Owner();
            using (var context = new DVLAEntities())
            {
                context.Owners.Add(owner);
                owner = OwnerDetailsInput(owner, 
                    input.FirstName!, input.LastName!, input.DateOfBirth, input.AddressId);
                context.SaveChanges();
                return GetOwner(owner.OwnerId);
            }
        }
        /// <summary>
        /// Convert the owner from database to the output format for API (OwnerModel)
        /// </summary>
        /// <param name="owner"> the owner from database </param>
        /// <returns> the Owner details with OwnerModel </returns>    
        private Owners OwnerToOwnerAPIModel(Owner owner)
        {
            return new Owners
            {
                OwnerId = owner.OwnerId,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                DateOfBirth = owner.DateOfBirth,
                AddressId = owner.AddressId,
                AddressLine1 = owner.Address.Line1,
                RowVersion = owner.RowVersion
            };
        }
        /// <summary>
        /// Convert the car from database to the output format for API (CarModel)
        /// </summary>
        /// <param name="car"> the car from database </param>
        /// <returns> the Car details with CarModel </returns>
        private Cars CarToCarAPIModel(Car car)
        {
            var carModel = new WebAPI.Models.Cars();
            carModel.CarId = car.CarId;
            carModel.RegistrationNumber = car.RegistrationNumber;
            carModel.ColourId = car.ColourId;
            carModel.Colour = car.Colour.Name;
            carModel.ModelId = car.ModelId;
            carModel.Model = car.Model.Name;
            carModel.MakeId = car.Model.Make.MakeId;
            carModel.Make = car.Model.Make.Name;
            carModel.RegistrationDate = car.RegistrationDate;
            carModel.OwnerId = car.OwnerId;
            carModel.OwnerFirstName = car.Owner.FirstName;
            carModel.OwnerLastName = car.Owner.LastName;
            return carModel;
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
        /// <summary>
        /// Perform parameters check for search input with the database specification
        /// </summary>
        /// <param name="firstName"> first name of the owner </param>
        /// <param name="lastName"> last name of th owner </param>
        /// <param name="dateOfBirth"> date of birth of the owner </param>
        /// <returns> false if fail search check, otherwise true </returns>
        private bool OwnerSearchCheck(string? firstName = null,
            string? lastName = null, DateTime? dateOfBirth = null)
        {
            if (!String.IsNullOrWhiteSpace(firstName))
            {
                if (firstName.Length > 40)
                {
                    return false;
                }
            }
            if (!String.IsNullOrWhiteSpace(lastName))
            {
                if (lastName.Length > 40)
                {
                    return false;
                }
            }
            if(dateOfBirth != null)
            {
                if(dateOfBirth > DateTime.Today)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Check the pagination parameters input
        /// </summary>
        /// <param name="pageNumber"> page number to display </param>
        /// <param name="itemPerPage"> item per page to display </param>
        /// <returns> false if fail search check, otherwise true </returns>
        private bool PaginationCheck(int pageNumber, int itemPerPage)
        {
            if (pageNumber < 1)
            {
                return false;
            }
            if (itemPerPage < 1)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Input owner details to th owner model 
        /// </summary>
        /// <param name="owner"> the owner model to input </param>
        /// <param name="firstName"> first name of owner to serach </param>
        /// <param name="lastName"> last name of owner to search </param>
        /// <param name="dateOfBirth"> date of birth of owner to search </param>
        /// <param name="addressId"> address id of the owner's address </param>
        /// <returns> the owner model with details input </returns>
        private EntityFrameWorkModel.Owner OwnerDetailsInput(Owner owner, string firstName, string lastName,
            DateTime dateOfBirth, int addressId)
        {
            owner.FirstName = firstName;
            owner.LastName = lastName;
            owner.DateOfBirth = dateOfBirth;
            owner.AddressId = addressId;
            return owner;
        }
        /// <summary>
        /// Check for Bad Request 400 error 
        /// </summary>
        /// <param name="isPutAPI"> is this a put api or not </param>
        /// <param name="ownerId"> owner id of the owner </param>
        /// <param name="firstName"> first name of owner to serach </param>
        /// <param name="lastName"> last name of owner to search </param>
        /// <param name="dateOfBirth"> date of birth of owner to search </param>
        /// <param name="addressId"> address id of the owner's address </param>
        /// <param name="rowVersion"> rowVersion of the owner details in database to avoid concurrency error </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsBadRequestCheck(bool isPutAPI, int? ownerId, string firstName,
            string lastName, DateTime? dateOfBirth, int? addressId, byte[]? rowVersion)
        {
            if (isPutAPI && (ownerId == null || ownerId <= 0))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(firstName))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            if (dateOfBirth == null)
            {
                return false;
            }
            if (addressId == null || addressId <= 0)
            {
                return false;
            }
            if(isPutAPI && rowVersion == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check for 422 unprocessable entity error 
        /// </summary>
        /// <param name="firstName"> first name of owner to serach </param>
        /// <param name="lastName"> last name of owner to search </param>
        /// <param name="dateOfBirth"> date of birth of owner to search </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsUnprocessableCheck(string firstName,
            string lastName, DateTime? dateOfBirth)
        {
            if (firstName.Length > 40)
            {
                return false;
            }
            if (lastName.Length > 40)
            {
                return false;
            }
            if (dateOfBirth > DateTime.Today)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check for 404 not found error 
        /// </summary>
        /// <param name="addressId"> address id of the owner's address </param>
        /// <returns> true if pass all check, otherwise false </returns>
        private bool InputDetailsNotFoundCheck(int addressId)
        {
            using (var context = new DVLAEntities())
            {
                if (context.Addresses.Find(addressId) == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
