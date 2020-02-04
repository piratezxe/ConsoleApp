using System.IO;
using System.Net;

namespace Sms
{
    public class FtpClient : IFtpClient
    {
        public string HostName { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public FtpClient(string hostName, string userName, string password)
        {
            UserName = userName;
            Password = password;
            HostName = hostName;
        }


        public void Download(string file, string destination)
        {
         
            FtpWebRequest request =
                (FtpWebRequest)WebRequest.Create(HostName + file);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials =
                new NetworkCredential(UserName, Password);
            FtpWebResponse response =
                (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            StreamWriter writer = new StreamWriter(destination);
            writer.Write(reader.ReadToEnd());

            writer.Close();
            reader.Close();
            response.Close();
        }
    }
    public class DiscClient : IFtpClient
    {
        public void Download(string file, string destination)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            File.Copy(file, destination);
        }
    }
}
