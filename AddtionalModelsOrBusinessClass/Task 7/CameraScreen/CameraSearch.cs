/*==============================================================================
 *
 * Camera Search List Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkModel;

namespace AddtionalModelsOrBusinessClass.Task_7.CameraScreen
{
    public class CameraSearch
    {
        public string LongtitudeFrom { get; set; }

        public string LongtitudeTo { get; set; }
        public string LatitudeFrom { get; set; }

        public string LatitudeTo { get; set; }
    }
}
