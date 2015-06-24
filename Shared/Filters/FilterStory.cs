using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Filters
{
    public class FilterStory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTimeOffset PostedOnStDt { get; set; }
        public DateTimeOffset PostedOnEndDt { get; set; }
        public int UserId { get; set; }
    }
}
