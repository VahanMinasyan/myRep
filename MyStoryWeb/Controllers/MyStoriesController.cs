using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared.Enums;
using MyStoryBLL;
using MyStoryBLL.Implementaions;
using MyStoryDAL.DataModels;
using Shared.Filters;
using MyStoryWeb.Models;


namespace MyStoryWeb.Controllers
{
    public class MyStoriesController : Controller
    {
        //
        // GET: /MyStories/
        public ActionResult Index()
        {
            List<Story> stories;
            using (BLFactory factory = new StoryBL())
            {
                StoryBL bl = (StoryBL)factory;
                stories = bl.GetStories(new FilterStory()
                {
                    UserId = Const.TestUser.ID,
                    PostedOnStDt = DateTimeOffset.Now.AddDays(-1),
                    PostedOnEndDt = DateTimeOffset.Now.AddDays(+1)
                }).OrderBy(x => x.PostedOn).Take(50).ToList();
            }
   
            return View(DataModelToViewModel(stories));
        }
        // Transfering Datamodel to ViewModel.
        public MyStoriesViewModel DataModelToViewModel(List<Story> stories)
        {
            MyStoriesViewModel model = new MyStoriesViewModel();
            model.Stories = new List<MyStoryViewModel>();
            foreach(var story in stories)
            {
                model.Stories.Add(new MyStoryViewModel() { 
                    ID = story.Id,
                    Title = story.Title
                });
            }
            return model;
        }
	}
}