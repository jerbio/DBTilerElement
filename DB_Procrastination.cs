using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_Procrastination : Procrastination
    {
        public DB_Procrastination(DateTimeOffset FromTimeData, DateTimeOffset BeginTimeData, int DisLikedSection)
        {
            FromTime = FromTimeData;
            BeginTIme = BeginTimeData;
            if (_FromTime == DateTime.MinValue)
            {
                _FromTime = Utility.JSStartTime;
            }
            if (BeginTIme == DateTime.MinValue)
            {
                BeginTIme = Utility.JSStartTime;
            }
            SectionOfDay = DisLikedSection;
        }
    }
}