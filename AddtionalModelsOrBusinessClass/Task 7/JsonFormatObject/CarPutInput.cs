﻿/*==============================================================================
 *
 * Car Input Model for API car response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject
{
    /// <summary>
    /// Object for API response related to car
    /// </summary>
    public class CarPutInput
    {
        /// <summary>
        /// The id of the car
        /// </summary>
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
        public int ModelId { get; set; }
        /// <summary>
        /// The Model of the car
        /// </summary>
        public System.DateTime RegistrationDate { get; set; }
        /// <summary>
        /// The id of the owern in database
        /// </summary>
        public int OwnerId { get; set; }
    }
}