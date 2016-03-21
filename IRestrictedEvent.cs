using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTilerElement
{
    interface IRestrictedEvent
    {
        DB_RestrictionProfile Restriction{ get; set; }
    }
}
