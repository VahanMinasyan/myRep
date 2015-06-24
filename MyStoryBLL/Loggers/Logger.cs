using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryBLL.Loggers
{
    public class Logger
    {
        private List<ILogger> Loggers;
        private static Logger _logger = null;
        public static Logger Instance
        {
            get
            {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                return _logger;
            }
        }

        private Logger()
        {
            Loggers = new List<ILogger>();
        }

        public void AddObeserver(ILogger logger)
        {
            if (!Loggers.Contains(logger))
            {
                Loggers.Add(logger);
            }
        }
        public void WriteLogMessage(string message)
        {
            foreach (ILogger logger in Loggers)
            {
                logger.ProcessLog(message);
            }
        }
    }
}
