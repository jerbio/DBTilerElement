using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;
using System.Xml.Serialization;
using System.Xml;
using System.IO;


namespace DBTilerElement
{
    class DB_Classification:Classification
    {

        public string ToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
                                                      // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, this);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.DocumentElement.InnerXml;
            }
        }

        public string Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        [XmlElement("Placement")]
        public string Placement
        {
            get
            {
                return _Placement.ToString();
            }
            set
            {
                _Placement = (Vicinity)Enum.Parse(typeof(Vicinity), value);
            }
        }

        [XmlElement("Succubus")]
        public string Succubus
        {
            get
            {
                return _Succubus.ToString();
            }
            set
            {
                _Succubus = (EnergyDifferential)Enum.Parse(typeof(EnergyDifferential), value);
            }
        }

        [XmlElement("LeisureType")]
        public string LeisureType
        {
            get
            {
                return _LeisureType.ToString();
            }
            set
            {
                _LeisureType = (Leisure)Enum.Parse(typeof(Leisure), value);
            }
        }

        [XmlElement("Initialized")]
        public string Initialized
        {
            get
            {
                return _Initialized.ToString();
            }
            set
            {
                _Initialized = Convert.ToBoolean (value);
            }
        }
    }
}
