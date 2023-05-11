/*==============================================================================
 *
 * Owner Search Display List Comparer Class
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
    /// Owner Search Owner Comparer
    /// </summary>
    public class OwnerDOBComp : IComparer<OwnerSearchDisplayList>
    {
        /// <summary>
        /// Owner Search Owner Comparer
        /// </summary>
        /// <param name="x"> first owner search dispaly list </param>
        /// <param name="y"> second owner search display list </param>
        /// <returns> -1, 0 or 1 </returns>
        public int Compare(OwnerSearchDisplayList x, OwnerSearchDisplayList y)
        {
            if (x.DateOfBirth.CompareTo(y.DateOfBirth) != 0)
            {
                return x.DateOfBirth.CompareTo(y.DateOfBirth);
            }
            else if (x.FirstName.CompareTo(y.FirstName) != 0)
            {
                return x.FirstName.CompareTo(y.FirstName);
            }
            else if (x.LastName.CompareTo(y.LastName) != 0)
            {
                return x.LastName.CompareTo(y.LastName);
            }
            else if (x.AddressLine1.CompareTo(y.AddressLine1) != 0)
            {
                return x.AddressLine1.CompareTo(y.AddressLine1);
            }
            else
            {
                return 0;
            }
        }
    }
}
