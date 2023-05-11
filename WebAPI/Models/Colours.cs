﻿/*==============================================================================
 *
 * Colour Model for API colour response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
namespace WebAPI.Models
{
    /// <summary>
    /// Colour Model for API output
    /// </summary>
    public class Colours
    {
        /// <summary>
        /// The id of the colour
        /// </summary>
        public int ColourId { get; set; }
        /// <summary>
        /// colour 
        /// </summary>
        public string? ColourName { get; set; }
    }
}