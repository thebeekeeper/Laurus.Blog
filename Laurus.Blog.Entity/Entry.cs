using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Blog.Entity
{
    public class Entry
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Content { get; set; }
		public virtual Blog Blog { get; set; }
        public virtual DateTime Created { get; set; }
    }
}
