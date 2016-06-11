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


    public class ScheduleContext : LocalDbContext
    {
        public ScheduleContext(): base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public ScheduleContext(string Connection = "DefaultConnection", bool throwIfV1Schema = false)
            : base(Connection, throwIfV1Schema: false)
        {
        }

        public static ScheduleContext Create()
        {
            return new ScheduleContext();
        }
    }

  
}
