/*==============================================================================
 *
 * Owner Model for API owner response
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
    /// Object for API response related to owner
    /// </summary>
    public class Owners
    {
        /// <summary>
        /// The id of the Owner
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// owner first name
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// owner last name
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Date Of birth the owner
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Id of the address of the owner
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// The address line1 of the owner 
        /// </summary>
        public string? AddressLine1 { get; set; }
        /// <summary>
        /// RowVersion of the current owner in database 
        /// </summary>
        public byte[]? RowVersion { get; set; }
    }
}
