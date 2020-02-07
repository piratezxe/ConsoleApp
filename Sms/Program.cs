

using Sms.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sms
{
    class Program
    {
        static void Main(string[] args)
        {
            IImportService importService = new SFtpImportService(new SFtpClient("", "", ""), new FileExtract(), new XmlService());
            importService.ImportSms(@"C:\Users\Karol\Desktop\Source", @"C:\Users\Karol\Desktop\target", "new1");
        }
    }
}
