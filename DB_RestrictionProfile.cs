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
            this._DaySelection = (new RestrictionDay[7]).ToList();
            foreach (RestrictionDay eachTuple in RestrictionTimeLineData)
            {
                DayOfWeek weekDay = TilerElements.Utility.ParseEnum<DayOfWeek>(eachTuple.DayOfWeekString);
                int index = (int)weekDay;
                _DaySelection[index] = eachTuple;
            }

            this.NoNull_DaySelections = RestrictionTimeLineData.OrderBy(obj => obj.DayOfWeekString).ToArray();
            InitializeOverLappingDictionary();
        }
    }
}