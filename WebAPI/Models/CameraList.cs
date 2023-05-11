/*==============================================================================
 *
 * Camera List Model for API camera response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
namespace WebAPI.Models
{
    /// <summary>
    /// The model for api return for multiple camera
    /// </summary>
    public class CameraList
    {
        /// <summary>
        /// The List of Cameras
        /// </summary>
        public List<Cameras>? Cameras { get; set; }
        /// <summary>
        /// the total available item that match the search results
        /// </summary>
        public int TotalAvailabeItem { get; set; }
    }
}
