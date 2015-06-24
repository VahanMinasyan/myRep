using MyStoryDAL.DataModels;
using Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryBLL.Implementaions
{
    public class GroupBL:CoreBL
    {
        public GroupBL(SessionInfo sessionInfo)
            : base(sessionInfo){}
        public GroupBL()
            : base(){}
       public List<Group> GetGroups(FilterGroup filter)
       {
           var query = dbContext.Group.AsNoTracking().AsQueryable();
           if (filter.Id !=0)
               query = query.Where(x => x.Id == filter.Id);
           if (!String.IsNullOrEmpty(filter.Description))
               query = query.Where(x => x.Description.Contains(filter.Description));
           if (!String.IsNullOrEmpty(filter.Name))
               query = query.Where(x => x.Name == filter.Name);
           return query.ToList();
       }
       public void AddGroup(Group newGroup)
       {
           Group groupFound = null;
           if (newGroup != null)
           {
               groupFound = dbContext.Group.FirstOrDefault(x => x.Name == newGroup.Name);
               if (groupFound == null)
                   dbContext.Group.Add(newGroup);
               SaveChanges();
           }
       }
    }
}
