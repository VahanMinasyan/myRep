namespace MyStoryWeb.Migrations
{
    using MyStoryBLL;
    using MyStoryBLL.Implementaions;
    using MyStoryDAL;
    using MyStoryDAL.DataModels;
    using Shared.Filters;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyStoryDAL.MyStoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyStoryDAL.MyStoryContext context)
        {
            /*Generating sample data for User Table*/
            List<string> names = new List<string> {"Johny","Mike","Tony","Jack","Jenny","Timy","Keny","Nancy","Woody","Dony","Mary","Dave","Keny","Jane" };
            List<string> sureNames = new List<string> { "Smith", "Black", "Magwaier","Mcdonalds","Wally","Dordmond","Wazowsky","Devito","Vandam","Donald" };
            using (BLFactory factory = new UserBL())
            {
                UserBL bl = (UserBL)factory;
                foreach (var name in names)
                {
                    foreach(var sureName in sureNames)
                    bl.AddUser(new User { Name = name +" "+ sureName});
                }
            }
            /*Generating sample data for Group Table*/
            Dictionary<string, string> groups = new Dictionary<string, string>();
            groups.Add("happy people", "How people should become happy");
            groups.Add("World Domination", "How to conquer the world");
            groups.Add("Funny Guy", "How to make a good joke");
            groups.Add("Nice Group", "Very Nice Group");
            groups.Add("Bad Group", "Very Depressed Group");
            using (BLFactory factory = new GroupBL())
            {
                GroupBL bl = (GroupBL)factory;
                foreach (var group in groups)
                {
                    bl.AddGroup(new Group { Description = group.Value, Name = group.Key });

                }
            }
            /*Generating sample data for Story table based on previously populated data*/
            List<User> DbUsers = null;
            List<Group> DbGroups = null;
            using (BLFactory factory = new GroupBL())
            {
                GroupBL bl = (GroupBL)factory;
                DbGroups = bl.GetGroups(new FilterGroup());
            }
            using (BLFactory factory = new UserBL())
            {
                UserBL bl = (UserBL)factory;
                DbUsers = bl.GetUsers(new FilterUser());
            }
            using (BLFactory factory = new StoryBL())
            {
                ICollection<Group> storyGroups = DbGroups;
                StoryBL bl = (StoryBL)factory;
                foreach (var user in DbUsers)
                {
                    bl.AddStory(new Story
                    {
                        Content = "Once apon a time there was a....",
                        Description = "old good story",
                        Group = storyGroups,
                        PostedOn = DateTimeOffset.Now,
                        Title = "MyStory",
                        UserId = user.Id
                    });
                }
            }
            //context.User.AddOrUpdate
            //(new User { Name = "arshak" }, new User { Name = "varsham" }, new User { Name = "varazdat" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
