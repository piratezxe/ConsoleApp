using System;
using System.IO;

namespace Sms
{
    public class DiscImportService : IImportService
    {
        private readonly IFtpClient _ftpClient;

        public string Source { get; private set; }

        public string Destination { get; private set; }

        public DiscImportService(IFtpClient ftpClient, string source, string destination)
        {
            _ftpClient = ftpClient;
            Source = source;
            Destination = destination;
        }

        public void ImportRecord(string source, string destination)
        {
            if (File.Exists(source))
            {
                // This path is a file
                ProcessFile(source);
            }
            else if (Directory.Exists(source))
            {
                // This path is a directory
                ProcessDirectory(source);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", source);
            }
        }
        private void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        private void ProcessFile(string path)
        {
            string targetPath = ReplaceWord(path, Source, Destination);
            _ftpClient.Download(path, targetPath);
        }

        public void ImportSms(string source, string destination)
        {
            throw new NotImplementedException();
        }

        public static string ReplaceWord(string text, string word, string newWord)
        {
            return text.Replace(word, newWord);
        }
    }
}
