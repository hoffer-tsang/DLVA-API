/*==============================================================================
 *
 * Sightings Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 6
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
    public class Sightings
    {
        public int SightingId { get; set; }
        public int CarId { get; set; }
        public int CameraId { get; set; }
        public DateTime SightingTime { get; set; }
        public byte SecondsAfterRedLight { get; set; }
        public byte SpeedMph { get; set; }
        
    }
}
