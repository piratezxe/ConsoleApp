using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sms
{
    public class Foo
    {
        [XmlArray("BarList"), XmlArrayItem(typeof(Bar), ElementName = "Bar")]
        public List<Bar> BarList { get; set; }
    }

    public class Bar
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}
