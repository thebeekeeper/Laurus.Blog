using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Blog.Service.DataContract
{
	public class Entry
	{
        public int Id { get; set; }
		public string Title { get; set; }
		public string OwnerDisplayName { get; set; }
		public string Content { get; set; }
        public DateTime Created { get; set; }
	}
}
