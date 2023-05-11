/*==============================================================================
 *
 * Car Model for API car response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject
{
    /// <summary>
    /// Object for API response related to car
    /// </summary>
    public class Cars
    {
        /// <summary>
        /// The id of the car
        /// </summary>
        [Key]
        public int CarId { get; set; }
        /// <summary>
        /// The registration number of the car
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// The id of the colour in database
        /// </summary>
        public int ColourId { get; set; }
        /// <summary>
        /// Colour of the car
        /// </summary>
        public string Colour { get; set; }
        /// <summary>
        /// The id of the model in database
        /// </summary>
        public int ModelId { get; set; }
        /// <summary>
        /// The Model of the car
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// The id of the make in database
        /// </summary>
        public int MakeId { get; set; }
        /// <summary>
        /// The make of the car
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// The registration date of the car
        /// </summary>
        public System.DateTime RegistrationDate { get; set; }
        /// <summary>
        /// The id of the owern in database
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// The car's owner first name
        /// </summary>
        public string OwnerFirstName { get; set; }
        /// <summary>
        /// The car's owner last name
        /// </summary>
        public string OwnerLastName { get; set; }

        public int CompareTo(Cars other)
        {
            throw new NotImplementedException();
        }
    }
}
