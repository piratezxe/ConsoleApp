using System.IO;
using System.Net;

namespace Sms
{
    public class FtpClient : IFtpClient
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

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
        public string HostName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string UserName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Password { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Download(string file, string destination)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            File.Copy(file, destination);
        }
    }
}
