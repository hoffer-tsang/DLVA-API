/*==============================================================================
 *
 * Car Model Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 4
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
    public class CarModel
    {
        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public int ColourId { get; set; }
        public int ModelId { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public int OwnerId { get; set; }
    }
}
