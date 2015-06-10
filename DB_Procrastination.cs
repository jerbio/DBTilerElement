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
            SectionOfDay = DisLikedSection;
        }
    }
}