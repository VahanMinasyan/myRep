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
        private StreamWriter _logWriter;

        public FileLoger(string fileName)
        {
            _logWriter = new StreamWriter(fileName);
        }

        public void ProcessLog(string message)
        {
            _logWriter.Write(message);
            _logWriter.Flush();
        }

        public void Dispose()
        {
            _logWriter.Close();
        }
    }
}
