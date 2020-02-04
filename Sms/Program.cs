

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms
{
    class Program
    {
        static void Main(string[] args)
        {
            IFtpClient ftpClient = new DiscClient();
            IImportService importService = new DiscImportService(ftpClient, "C:\\Users\\Karol\\Desktop\\ftp", "C:\\Users\\Karol\\Desktop\\local");
            importService.ImportRecord("C:\\Users\\Karol\\Desktop\\ftp", "C:\\Users\\Karol\\Desktop\\local");
        }
    }
}
