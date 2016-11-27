using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_RestrictionProfile : RestrictionProfile
    {
        public DB_RestrictionProfile(List<RestrictionDay> RestrictionTimeLineData)
        {
            this.DaySelection = new RestrictionDay[7];
            foreach (RestrictionDay eachTuple in RestrictionTimeLineData)
            {
                DaySelection[(int)eachTuple.DayOfWeek] = eachTuple;
            }

            this.NoNull_DaySelections = RestrictionTimeLineData.OrderBy(obj => obj.DayOfWeek).ToArray();
            InitializeOverLappingDictionary();
        }
    }
}