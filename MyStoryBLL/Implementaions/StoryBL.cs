using MyStoryDAL.DataModels;
using Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryBLL.Implementaions
{
    public class StoryBL:CoreBL
    {
        public StoryBL(SessionInfo sessionInfo)
            : base(sessionInfo){}
        public StoryBL()
            : base(){}
       public List<Story> GetStories(FilterStory filter)
       {
           var query = dbContext.Story.AsNoTracking().AsQueryable();
           if (filter.Id !=0)
               query = query.Where(x => x.Id == filter.Id);
           if (!String.IsNullOrEmpty(filter.Title))
               query = query.Where(x => x.Title.Contains(filter.Title));
           if (!String.IsNullOrEmpty(filter.Content))
               query = query.Where(x => x.Content.Contains(filter.Content));
           if (!String.IsNullOrEmpty(filter.Description))
               query = query.Where(x => x.Description.Contains(filter.Description));
           if (filter.PostedOnStDt !=null)
               query = query.Where(x => x.PostedOn>= filter.PostedOnStDt);
           if (filter.PostedOnEndDt != null)
               query = query.Where(x => x.PostedOn<= filter.PostedOnEndDt);
           return query.ToList();
       }
       public void AddStory(Story newStory)
       {
           User userFound=null;
           if (newStory != null)
               userFound = dbContext.User.FirstOrDefault(x => x.Id == newStory.UserId);
           if (userFound != null)
               dbContext.Story.Add(newStory);
           SaveChanges();
       }
    }
}
