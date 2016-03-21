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
        public DbSet<DB_SubCalendarEvent> SubCalendarevents { get; set; }
        public DbSet<DB_ModifiedSubCalendarEventFly> ModifiedSubCalendarevents { get; set; }
        public DbSet<DB_SubCalendarEventRestricted> RestrictedSubCalendarevents { get; set; }
        public DbSet<DB_Repetition> Repetitions { get; set; }
        public DbSet<DB_TilerEventName> CalendarEventEventNames { get; set; }
        public DbSet<ModifiedTilerEventName> ModifiedEventNames { get; set; }

        public ScheduleContext()
            : base("DefaultConnection")
        {
        }
    }

  
}
