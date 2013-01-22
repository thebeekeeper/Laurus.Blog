using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Blog.Entity
{
    public class Blog
    {
        public virtual int Id { get; set; }
        public virtual IEnumerable<Entry> Entries { get; set; }
        public virtual string Title { get; set; }

		public Blog()
		{
			Entries = new List<Entry>();
		}
    }
}
