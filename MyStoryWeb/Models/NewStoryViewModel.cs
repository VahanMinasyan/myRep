using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStoryWeb.Models
{
    public class NewStoryViewModel
    {
        public string Title { get; set;}
        public string Content { get; set; }
        public string Description { get; set; }
        public List<int> GroupIds { get; set; }
    }
}