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

        public string Id
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public int UnwanteDaySection
        {
            get
            {
                return SectionOfDay;
            }

            set
            {
                SectionOfDay = value;
            }
        }
    }
}