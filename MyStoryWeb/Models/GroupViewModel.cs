using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStoryWeb.Models
{
    public class GroupViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int memberQTY { get; set; }
        public int storyQTY { get; set; }
    }
}