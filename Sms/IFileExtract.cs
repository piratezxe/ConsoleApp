using SharpCompress.Archives;
using SharpCompress.Common;
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
            System.IO.Directory.CreateDirectory(extractPath);
            using (var archive = ArchiveFactory.Open(zipPath))
            {
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                        entry.WriteToDirectory(extractPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                }
            }
        }
    }
}
