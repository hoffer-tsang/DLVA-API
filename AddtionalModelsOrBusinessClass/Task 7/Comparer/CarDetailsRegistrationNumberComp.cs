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
using AddtionalModelsOrBusinessClass.Task_7.OwnerScreen;

namespace AddtionalModelsOrBusinessClass.Task_7.Comparer
{
    /// <summary>
    /// Car Search registration number comparer
    /// </summary>
    public class CarDetailsRegistrationNumberComp : IComparer<OwnerScreenCarList>
    {
        /// <summary>
        /// Car Search reg num Comparer
        /// </summary>
        /// <param name="x"> first car search dispaly list </param>
        /// <param name="y"> second car search display list </param>
        /// <returns> -1, 0 or 1 </returns>
        public int Compare(OwnerScreenCarList x, OwnerScreenCarList y)
        {
            if (x.RegistrationNumber.CompareTo(y.RegistrationNumber) != 0)
            {
                return x.RegistrationNumber.CompareTo(y.RegistrationNumber);
            }
            else if (x.Model.CompareTo(y.Model) != 0)
            {
                return x.Model.CompareTo(y.Model);
            }
            else if (x.Make.CompareTo(y.Make) != 0)
            {
                return x.Make.CompareTo(y.Make);
            }
            else if (x.Colour.CompareTo(y.Colour) != 0)
            {
                return x.Colour.CompareTo(y.Colour);
            }
            else
            {
                return 0;
            }
        }
    }
}
