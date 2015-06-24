using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryDAL.DataModels
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTimeOffset PostedOn { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Group> Group { get; set; }
    }
}
