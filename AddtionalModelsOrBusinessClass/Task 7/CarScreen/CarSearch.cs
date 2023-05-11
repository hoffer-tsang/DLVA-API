/*==============================================================================
 *
 * Car Search List Class
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

namespace AddtionalModelsOrBusinessClass.Task_7.CarScreen
{
    public class CarSearch
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }

        public string Make { get; set; }
        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }
    }
}
