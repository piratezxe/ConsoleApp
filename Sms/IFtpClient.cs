using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms
{
    public interface IFtpClient
    {
        string HostName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        void Download(string file, string destination);
    }
}
