using Renci.SshNet;
using System;
using System.IO;
using System.Net;

namespace Sms
{
    public class SFtpClient : ISFtpClient
    {
        public string HostName { get;  set; }

        public string UserName { get;  set; }

        public string Password { get;  set; }

        public SFtpClient(string hostName, string userName, string password)
        {
            UserName = userName;
            Password = password;
            HostName = hostName;
        }


        public void Download(string filePath, string targetPath)
        {
            using (SftpClient sftp = new SftpClient(HostName, UserName, Password))
            {
                try
                {
                    sftp.Connect();

                    using (Stream fileStream = File.Create(targetPath))
                    {
                        sftp.DownloadFile(filePath, fileStream);
                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }
    }
}
