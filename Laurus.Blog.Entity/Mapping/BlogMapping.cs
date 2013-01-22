using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Laurus.Blog.Entity.Mapping
{
	public class BlogMapping : ClassMap<Blog>
	{
		public BlogMapping()
		{
			Id(x => x.Id);
			Map(x => x.Title);
		}
	}

	public class EntryMapping : ClassMap<Entry>
	{
		public EntryMapping()
		{
			Id(x => x.Id);
			Map(x => x.Name);
			Map(x => x.Content);
		}
	}
}
