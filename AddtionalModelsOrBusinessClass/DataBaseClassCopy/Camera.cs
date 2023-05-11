/*==============================================================================
 *
 * Camera Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 5
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkModel;

namespace AddtionalModelsOrBusinessClass.Data
{
    public class Camera
    {
        public int CameraId { get; set; }
        public string RoadName { get; set; }
        public string RoadNumber { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int AddressId { get; set; }
    }
}
