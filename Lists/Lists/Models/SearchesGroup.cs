using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.Models
{
    public class SearchesGroup : List<Search>, IEnumerable<Search>
    {
        public string Title { get; set; }
        public SearchesGroup(string title)
        {
            Title = title;
        }
    }
}
