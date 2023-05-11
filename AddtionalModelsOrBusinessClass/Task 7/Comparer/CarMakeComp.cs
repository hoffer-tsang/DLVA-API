/*==============================================================================
 *
 * Car Search Display List Comparer Class
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
using AddtionalModelsOrBusinessClass.Task_7.CarScreen;

namespace AddtionalModelsOrBusinessClass.Task_7.Comparer
{
    /// <summary>
    /// Car Search Make Comparer
    /// </summary>
    public class CarMakeComp : IComparer<CarSearchDisplayList>
    {
        /// <summary>
        /// Car Search Make Comparer
        /// </summary>
        /// <param name="x"> first car search dispaly list </param>
        /// <param name="y"> second car search display list </param>
        /// <returns> -1, 0 or 1 </returns>
        public int Compare(CarSearchDisplayList x, CarSearchDisplayList y)
        {
            if (x.Make.CompareTo(y.Make) != 0)
            {
                return x.Make.CompareTo(y.Make);
            }
            else if (x.RegistrationNumber.CompareTo(y.RegistrationNumber) != 0)
            {
                return x.RegistrationNumber.CompareTo(y.RegistrationNumber);
            }
            else if (x.Model.CompareTo(y.Model) != 0)
            {
                return x.Model.CompareTo(y.Model);
            }
            
            else if (x.Owner.CompareTo(y.Owner) != 0)
            {
                return x.Owner.CompareTo(y.Owner);
            }
            else
            {
                return 0;
            }
        }
    }
}
