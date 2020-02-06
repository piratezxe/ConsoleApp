

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
            IFtpClient ftpClient = new FtpClient("ftp://test.rebex.net/","demo", "password");
            IImportService importService = new FtpImportService(ftpClient);
            //importService.ImportRecord("ftp://test.rebex.net/pub/example/", "C:\\Users\\Karol\\Desktop\\local");
            importService.ImportRecord("ftp://test.rebex.net/pub/", "C:\\Users\\Karol\\Desktop\\local");
        }
    }
}
