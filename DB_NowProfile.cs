using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_NowProfile : NowProfile
    {
        public DB_NowProfile(DateTimeOffset preferredTimeData, bool InitializedData)
            : base(preferredTimeData, InitializedData)
        {
        
        }
    }
}