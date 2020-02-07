using System;

namespace Sms
{
    public interface IImportService
    {
        void ImportRecord(string source, string destination);
        void ImportSms(string source, string destination, string zipName);
    }
}
