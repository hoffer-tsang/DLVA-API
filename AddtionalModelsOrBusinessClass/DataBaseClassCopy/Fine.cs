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
    public class Fine
    {
        public int SightingId { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DatePaid { get; set; }

    }
}
