﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WinSCP;

namespace Sms
{
    public class SFtpImportService : IImportService
    {
        private readonly ISFtpClient _ftpClient;

        private readonly IFileExtract _fileExtract;

        private readonly IXmlService _xmlService;

        public SFtpImportService(ISFtpClient ftpClient, IFileExtract fileExtract, IXmlService xmlService)
        {
            _ftpClient = ftpClient;
            _fileExtract = fileExtract;
            _xmlService = xmlService;
        }
        public void ImportRecord(string source, string destination)
        {
        }

        public void ImportSms(string source, string destination, string zipName)
        {
            var destinationZipPath = Path.Combine(destination, zipName);

            //pobranie na zasoby
            //_ftpClient.Download(Path.Combine(source, zipName), destinationZipPath);


            var zipPath = Path.Combine(destination, zipName + ".zip");
            _fileExtract.ExtractFile(zipPath, destinationZipPath);

            string[] files = Directory.GetFiles(destination, "*.xml", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var sms = _xmlService.GetObjectFromPath<Foo>(file);
                //sms zapis do bazy danych
            }
        }
    }
}
