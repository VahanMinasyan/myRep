using System.Reflection;
using MyStoryBLL.Implementaions;
using MyStoryDAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStoryBLL.Loggers;
using MyStoryDAL;
using log4net;

namespace MyStoryBLL.Loggers
{
    public class Log4netLocal : ILogger
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Log4netLocal()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public void ProcessLog(string message)
        {
            log.Info(message);
        }

       
    }
}
