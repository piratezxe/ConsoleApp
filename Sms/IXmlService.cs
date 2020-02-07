using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sms
{
    public interface IXmlService
    {
        T GetObjectFromPath<T>(string path);
    }
    public class XmlService : IXmlService
    {
        public T GetObjectFromPath<T>(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            string xmlcontents = doc.InnerXml;
            var foo = new GenericXMLSerializer<T>();
            return foo.Deserialize(xmlcontents);
        }
    }
}
