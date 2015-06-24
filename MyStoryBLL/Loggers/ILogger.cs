using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryBLL.Loggers
{
    public interface ILogger
    {
        void ProcessLog(string message);
    }
}
