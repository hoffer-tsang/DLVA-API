/*==============================================================================
 *
 * Owner List Model for API owner response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
namespace WebAPI.Models
{
    /// <summary>
    /// The model for api return for multiple owner 
    /// </summary>
    public class OwnerList
    {
        /// <summary>
        /// The List of Owners
        /// </summary>
        public List<Owners>? Owners { get; set; }
        /// <summary>
        /// the total available item that match the search results
        /// </summary>
        public int TotalAvailabeItem { get; set; }
    }
}
