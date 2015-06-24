using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryDAL.DataModels
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation property
        public virtual ICollection<Story> Story { get; set; }
    }
}
