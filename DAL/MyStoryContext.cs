using MyStoryDAL.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryDAL
{
    public class MyStoryContext : DbContext
    {
        public MyStoryContext()
            : base("LocalConnection")
        {
            //If model change, It will re-create new database.
            Database.SetInitializer<MyStoryContext>(new CreateDatabaseIfNotExists<MyStoryContext>());
        }
        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
