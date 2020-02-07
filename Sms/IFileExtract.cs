using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms
{
    public interface IFileExtract
    {
        void ExtractFile(string zipPath, string extractPath);
    }
    public class FileExtract : IFileExtract
    {
        public void ExtractFile(string zipPath, string extractPath)
        {
            System.IO.Directory.CreateDirectory(extractPath);
            //System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                }
            }
        }
    }
    public class SevenZipFIleExtract : IFileExtract
    {
        public void ExtractFile(string zipPath, string extractPath)
        {
            string zPath = "7za.exe"; //add to proj and set CopyToOuputDir
            try
            {
                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", zipPath, extractPath);
                Process x = Process.Start(pro);
                x.WaitForExit();
            }
            catch (System.Exception Ex)
            {
                //handle error
            }
        }
    }
}
