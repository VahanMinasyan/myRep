using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoryDAL.DataModels
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Exception { get; set; }
    }
}
