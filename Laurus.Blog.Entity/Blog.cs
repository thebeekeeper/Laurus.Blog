using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Blog.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
        public string Title { get; set; }

		public Blog()
		{
			Entries = new List<Entry>();
		}
    }
}
