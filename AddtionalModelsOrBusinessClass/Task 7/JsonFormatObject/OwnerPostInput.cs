/*==============================================================================
 *
 * Owner Post Model for API owner response
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
    /// Object for API response related to owner
    /// </summary>
    public class OwnerPostInput
    {
        /// <summary>
        /// owner first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// owner last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Date Of birth the owner
        /// </summary>
        public System.DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Id of the address of the owner
        /// </summary>
        public int AddressId { get; set; }
    }
}
