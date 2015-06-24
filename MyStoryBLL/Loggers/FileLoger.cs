using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryBLL.Loggers
{
    public class FileLoger : ILogger, IDisposable
    {
        private StreamWriter lgWriter;

        public FileLoger(string fileName)
        {
            lgWriter = new StreamWriter(fileName);
        }

        public void ProcessLog(string message)
        {
            lgWriter.Write(message);
            lgWriter.Flush();
        }

        public void Dispose()
        {
            lgWriter.Close();
        }
    }
}
