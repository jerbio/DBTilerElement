using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;
namespace DBTilerElement
{
    class DB_MiscData:MiscData
    {


        #region property

        public new string UserNote
        {
            get
            {
                return UserTypedData;
            }
            set
            {
                UserTypedData = value;
            }
        }


        public new int TypeSelection
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }

        #endregion
    }
}
