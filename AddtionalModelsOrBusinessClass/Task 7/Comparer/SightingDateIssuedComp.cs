/*==============================================================================
 *
 * Sighting Search Display List Comparer Class
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddtionalModelsOrBusinessClass.Task_7.Sightings;

namespace AddtionalModelsOrBusinessClass.Task_7.Comparer
{
    /// <summary>
    /// Sighting Search Make Comparer
    /// </summary>
    public class SightingDateIssuedComp : IComparer<SightingsListDisplay>
    {
        /// <summary>
        /// Sighting Search Make Comparer
        /// </summary>
        /// <param name="x"> first Sighting search dispaly list </param>
        /// <param name="y"> second Sighting search display list </param>
        /// <returns> -1, 0 or 1 </returns>
        public int Compare(SightingsListDisplay x, SightingsListDisplay y)
        {
            if (x.DateIssued.CompareTo(y.DateIssued) != 0)
            {
                return x.DateIssued.CompareTo(y.DateIssued);
            }
            else if (x.SightingTime.CompareTo(y.SightingTime) != 0)
            {
                return x.SightingTime.CompareTo(y.SightingTime);
            }
            else if (x.SecondsAfterRedLight.CompareTo(y.SecondsAfterRedLight) != 0)
            {
                return x.SecondsAfterRedLight.CompareTo(y.SecondsAfterRedLight);
            }
            else if (x.Speed.CompareTo(y.Speed) != 0)
            {
                return x.Speed.CompareTo(y.Speed);
            }
            else if (x.DatePaid.CompareTo(y.DatePaid) != 0)
            {
                return x.DatePaid.CompareTo(y.DatePaid);
            }
            else
            {
                return 0;
            }
        }
    }
}
