using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public class DB_TilerUserGroup: TilerUserGroup
    {
        public string ThirdPartyId { get; set; }
        public bool isNull { get; set; } = true;
        public string Id {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }
        }

        public ICollection<TilerUser> Users
        {
            get
            {
                return this._Users ?? (_Users = new List<TilerUser>());
            }
            set
            {
                this._Users = value;
            }
        }
    }
}
