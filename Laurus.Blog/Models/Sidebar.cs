using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurus.Blog.Models
{
    public class Sidebar
    {
        public string Title { get; set; }
        public string TagLine { get; set; }
        public IEnumerable<SidebarLink> Links { get; set; }

        public Sidebar()
        {
            Links = new List<SidebarLink>();
        }
    }

    public class SidebarLink
    {
        public string DisplayText {get;set;}
        public int CategoryId { get; set; }
    }
}