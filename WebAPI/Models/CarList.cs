﻿/*==============================================================================
 *
 * CarList Model for API car response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebAPI.Models
{
    /// <summary>
    /// Object for API response related to car
    /// </summary>
    public class CarList
    {
        /// <summary>
        /// A list of car that match search requirement 
        /// </summary>
        [Key]
        public List<Cars>? Car { get; set; }
        /// <summary>
        /// The total available item that match search requirement 
        /// </summary>
        public int TotalAvailabeItem { get; set; }
    }
}
