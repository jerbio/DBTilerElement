#define UseDefaultLocation

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using TilerElements.Wpf;
using TilerElements.DB;
using System.Threading.Tasks;
//using DBTilerElement;
using System.Diagnostics;
#if ForceReadFromXml
#else
//using CassandraUserLog;
using TilerSearch;
#endif



namespace DBTilerElement
{
    public class WebScheduleControl:ScheduleControl
    {
        public WebScheduleControl()
        {
            DataBase = new ScheduleContext();
        }
    }

}
