/*==============================================================================
 *
 * Car Model for API model response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
namespace WebAPI.Models
{
    /// <summary>
    /// Car Model for API output
    /// </summary>
    public class Models
    {
        /// <summary>
        /// The id of the car model
        /// </summary>
        public int ModelId { get; set; }
        /// <summary>
        /// name of the car model
        /// </summary>
        public string? ModelName { get; set; }
    }
}
