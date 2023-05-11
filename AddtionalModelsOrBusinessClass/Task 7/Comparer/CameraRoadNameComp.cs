/*==============================================================================
 *
 * Camera Search Display List Comparer Class
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
using AddtionalModelsOrBusinessClass.Task_7.CameraScreen;

namespace AddtionalModelsOrBusinessClass.Task_7.Comparer
{
    /// <summary>
    /// Camera Search Make Comparer
    /// </summary>
    public class CameraRoadNameComp : IComparer<CameraSearchDisplayList>
    {
        /// <summary>
        /// Camera Search Make Comparer
        /// </summary>
        /// <param name="x"> first Camera search dispaly list </param>
        /// <param name="y"> second Camera search display list </param>
        /// <returns> -1, 0 or 1 </returns>
        public int Compare(CameraSearchDisplayList x, CameraSearchDisplayList y)
        {
            if (x.RoadName.CompareTo(y.RoadName) != 0)
            {
                return x.RoadName.CompareTo(y.RoadName);
            }
            else if (x.CameraType.CompareTo(y.CameraType) != 0)
            {
                return x.CameraType.CompareTo(y.CameraType);
            }   
            else if (x.Longitude.CompareTo(y.Longitude) != 0)
            {
                return x.Longitude.CompareTo(y.Longitude);
            }
            else if (x.Latitude.CompareTo(y.Latitude) != 0)
            {
                return x.Latitude.CompareTo(y.Latitude);
            }
            else
            {
                return 0;
            }
        }
    }
}
