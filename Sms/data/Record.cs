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
    }
}
