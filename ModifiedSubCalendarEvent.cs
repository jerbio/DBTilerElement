using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTilerElement
{
    public class DB_ModifiedSubCalendarEventFly : DB_SubCalendarEventFly, IModifieds
    {
        public override bool isDeviated
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
