using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TilerElements.Wpf;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TilerElements;

namespace DBTilerElement
{


    public class ScheduleContext : DbContext
    {
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<SubCalendarEvent> SubCalendarevents { get; set; }
        public DbSet<Repetition> Repetitions { get; set; }

        public ScheduleContext()
            : base("DefaultConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }

  
}
