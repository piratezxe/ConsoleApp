using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms
{
    public interface IFtpClient
    {
        void Download(string file, string destination);
    }
}
