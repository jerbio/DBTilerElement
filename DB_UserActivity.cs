using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TilerElements;

namespace DBTilerElement
{
    public class DB_UserActivity : UserActivity
    {
        public DB_UserActivity(ReferenceNow triggerTime, ActivityType type):base(triggerTime, type)
        {

        }

        public string ToXML()
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(stringwriter, this);
            return stringwriter.ToString();
        }

        public static DB_UserActivity LoadFromXMLString(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(DB_UserActivity));
            return serializer.Deserialize(stringReader) as DB_UserActivity;
        }
    }
}
