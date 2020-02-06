using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WinSCP;

namespace Sms
{
    class FtpImportService : IImportService
    {
        private readonly IFtpClient _ftpClient;
        public FtpImportService(IFtpClient ftpClient)
        {
            _ftpClient = ftpClient;
        }
        public void ImportRecord(string source, string destination)
        {
            NetworkCredential credentials = new NetworkCredential(_ftpClient.UserName, _ftpClient.Password);
            DownloadFtpDirectory(source, credentials, destination);
        }

        public void ImportSms(string source, string destination)
        {
            throw new System.NotImplementedException();
        }
        void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
        {
            // Setup session options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "test.rebex.net",
                UserName = credentials.UserName,
                Password = credentials.Password
            };

            using (Session session = new Session())
            {
                // Connect
                session.Open(sessionOptions);

                // List files

                foreach(var a  in session.EnumerateRemoteFiles("/", null, EnumerationOptions.AllDirectories))
                {
                    var filePath = a.FullName;
                    var fileName = a.Name;
                }

                //IEnumerable<string> list =
                //    session.EnumerateRemoteFiles("/", null, EnumerationOptions.None).
                //    Select(fileInfo => fileInfo.FullName);
                //var cos = list.Count();
            }
        }
    }
}
