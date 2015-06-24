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
namespace MyStoryBLL
{
    public abstract class CoreBL:BLFactory,IDisposable
    {
        public CoreBL(SessionInfo sessionInfo)
            : base(sessionInfo){}
        public CoreBL()
            : base(){}
        protected override void CreateBL(SessionInfo sessionInfo){
            this.dbContext = new MyStoryContext();
            this.sessionInfo = sessionInfo;
            var fileLoger = new FileLoger("logFile.txt");
            var log4NetLocal = new Log4netLocal();
            //subscribes loggers to Observer
            Logger.Instance.AddObeserver(log4NetLocal);
            Logger.Instance.AddObeserver(fileLoger);
        }
        //initialize session with defeault values
        protected override void CreateBL(){ 
            sessionInfo = new SessionInfo();
            dbContext = new MyStoryContext();
        }
        //Save changes to DB
        public void SaveChanges()
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    // logs info using all subscribed loggers
                    Logger.Instance.WriteLogMessage(string.Format("{0}:{1}", DateTime.Now, ex.Message));
                }
                finally                
                {
                }
            }
        }
        public void Dispose()
        {
            
        }
    }
}
