﻿/*==============================================================================
 *
 * Sightings List Model for API response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/

using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    /// Object for API response related to sightings
    /// </summary>
    public class SightingsList
    {
        /// <summary>
        /// List of Sightings
        /// </summary>
        public List<Sightings>? Sightings { get; set; }
        /// <summary>
        /// The total available item that match search requirement 
        /// </summary>
        public int TotalAvailabeItem { get; set; }
    }
}