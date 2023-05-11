/*==============================================================================
 *
 * Address Model for API address response
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
    /// Object for API response related to address
    /// </summary>
    public class Addresses
    {
        /// <summary>
        /// The id of the address
        /// </summary>
        [Key]
        public int AddressId { get; set; }
        /// <summary>
        /// Line 1 of address
        /// </summary>
        public string? Line1 { get; set; }
        /// <summary>
        /// Line 2 of address
        /// </summary>
        public string? Line2 { get; set; }
        /// <summary>
        /// Line 3 of address
        /// </summary>
        public string? Line3 { get; set; }
        /// <summary>
        /// City of the address
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// County of the address
        /// </summary>
        public string? County { get; set; }
        /// <summary>
        /// Country of the address
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// Post Code of the address
        /// </summary>
        public string? PostalCode { get; set; }
    }
}
