using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public class DB_TilerUser: TilerUser
    {
        public bool isNull { get; set; } = true;
        public string Email { get; set; } 
        public string ThirdPartyUserIdentifier { get; set; } 
    }
}
