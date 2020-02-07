using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.data
{
    public class recording
    {
        public string recId { get; set; }

        public int length { get; set; }

        public string encryptedPassword { get; set; }

        public string otherPartyAdrtess { get; set; }

        public string checkSum { get; set; }

        public string recDirection { get; set; }

        public DateTime establishedTime { get ; set; }

//        <?xml version = "1.0" ?>
//< Foo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
//  <BarList>
//    <Bar>
//      <Property1>abc</Property1>
//      <Property2>def</Property2>
//    </Bar>
//  </BarList>
//</Foo>
    }
}
