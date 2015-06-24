using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStoryWeb.Models
{
    
    public class MyStoriesViewModel
    {
        public List<MyStoryViewModel> Stories;
    }
    public class MyStoryViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
}