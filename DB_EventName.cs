using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public class DB_EventName: EventName
    {
        public DB_EventName(TilerUser tilerUser, TilerEvent tilerEvent, string name, string id)
        {
            _Name = name;
            _Id = id;
            this._Creator = tilerUser;
            this._Event = tilerEvent;
        }

        public DB_EventName()
        {}

        virtual public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        override public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
    }
}
