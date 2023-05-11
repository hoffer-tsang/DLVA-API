/*==============================================================================
 *
 * Make Model for API make response
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/
namespace AddtionalModelsOrBusinessClass.Task_7.JsonFormatObject
{
    /// <summary>
    /// Make Model for API output
    /// </summary>
    public class Makes
    {
        /// <summary>
        /// The id of the make
        /// </summary>
        public int MakeId { get; set; }
        /// <summary>
        /// name of the car making company
        /// </summary>
        public string MakeName { get; set; }
    }
}
