using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurus.Blog.Models
{
    public class EntryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Created { get; set; }
    }
}