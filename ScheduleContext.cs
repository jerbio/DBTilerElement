using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DBTilerElement
{
    public class ScheduleContext : DbContext
    {
        public DbSet<DB_CalendarEventFly> CalendarEvents { get; set; }
        public DbSet<DB_SubCalendarEventFly> SubCalendarevents { get; set; }
        public DbSet<DB_Repetition> Repetions { get; set; }
        public DbSet<DB_LocationElements> Locations { get; set; }

        public ScheduleContext()
            : base("DefaultConnection")
        {
        }
    }
}
