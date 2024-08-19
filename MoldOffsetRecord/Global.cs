using System.IO;

namespace MoldOffsetRecord
{
    class Global
    {        
        public static string localLogFilePath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\MES\"));
        public static string searchFileDirectory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\DownloadedFiles\"));
    }
}
