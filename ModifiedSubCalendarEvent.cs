using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements.DB;

namespace DBTilerElement
{
    public class DB_ModifiedSubCalendarEventFly : DB_SubCalendarEventFly, IModifieds
    {
        public override bool isRestricted
        {
            get
            {
                return true;
            }
        }
        public string UnmodifiedCalendarEventId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
