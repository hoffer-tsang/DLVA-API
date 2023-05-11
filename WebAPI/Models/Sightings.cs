/*==============================================================================
 *
 * Sightings Model for API response
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
    public class Sightings
    {
        /// <summary>
        /// The id of the sighting
        /// </summary>
        [Key]
        public int SightingId { get; set; }
        /// <summary>
        /// The id of the car in this sighting
        /// </summary>
        public int CarId { get; set; }
        /// <summary>
        /// The id of the camera that record this sighting
        /// </summary>
        public int CameraId { get; set; }
        /// <summary>
        /// The time occur of this sighting
        /// </summary>
        public System.DateTime SightingTime { get; set; }
        /// <summary>
        /// The time record by the traffic light camera
        /// </summary>
        public int? SecondsAfterRedLight { get; set; }
        /// <summary>
        /// The speed record by the speed camera
        /// </summary>
        public int? SpeedMph { get; set; }
        /// <summary>
        /// The Date time of fine issued 
        /// </summary>
        public DateTime? DateIssued { get; set; }
        /// <summary>
        /// The Date time of fine paid
        /// </summary>
        public DateTime? DatePaid { get; set; }
    }
}
