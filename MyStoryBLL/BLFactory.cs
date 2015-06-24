using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStoryDAL;
using MyStoryDAL.DataModels;
using MyStoryBLL.Implementaions;

namespace MyStoryBLL
{
    //creator of BL
    public abstract class BLFactory:IDisposable
    {
        //The product of factory is context
        protected MyStoryContext dbContext;
        //session keeps general info regarding language timeZone etc...
        protected SessionInfo sessionInfo;
        //Factory Methods
        protected abstract void CreateBL(SessionInfo sessionInfo);
        protected abstract void CreateBL();
        public BLFactory(SessionInfo sessionInfo)
        {
            CreateBL(sessionInfo);
        }
        public BLFactory()
        {
            CreateBL(new SessionInfo());
        }
        public void Dispose()
        {

        }

    }
}


