/*==============================================================================
 *
 * Camera Put Input Model for API camera response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/

namespace AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject
{
    /// <summary>
    /// Object for API response related to camera
    /// </summary>
    public class CameraPutInput
    {
        /// <summary>
        /// The id of the camera
        /// </summary>
        public int CameraId { get; set; }
        /// <summary>
        /// Road Name of the camera location
        /// </summary>
        public string RoadName { get; set; }
        /// <summary>
        /// Road number of the camera location
        /// </summary>
        public string RoadNumber { get; set; }
        /// <summary>
        /// longitude of the camera location
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// latitude of the camera location
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// Address id of the camera's address 
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// Camera type of the camera 
        /// ANPR, traffic light camera, speed camera
        /// </summary>
        public string CameraType { get; set; }
        /// <summary>
        /// The Camera threshold value, seconds after red light for tarffic light camera
        /// and speed limit for speed camera
        /// </summary>
        public byte? CameraLimitValue { get; set; }
    }
}
