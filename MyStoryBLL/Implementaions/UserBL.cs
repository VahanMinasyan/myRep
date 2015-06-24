using MyStoryDAL.DataModels;
using Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryBLL.Implementaions
{
    public class UserBL:CoreBL
    {
       public UserBL(SessionInfo sessionInfo)
            : base(sessionInfo){}
       public UserBL()
            : base(){}
       public List<User> GetUsers(FilterUser filter)
       {
           var query = dbContext.User.AsNoTracking().AsQueryable();
           if (filter.Id !=0)
               query = query.Where(x => x.Id == filter.Id);
           if(!String.IsNullOrEmpty(filter.Name))
               query = query.Where(x => x.Name == filter.Name);
           return query.ToList();
       }
       public void AddUser(User newUser)
       {
           User userFound=null;
           if (newUser != null)
           {
               userFound = dbContext.User.FirstOrDefault(x => x.Name == newUser.Name);
               if (userFound == null)
                   dbContext.User.Add(newUser);
               SaveChanges();
           }
       }
    }
}
