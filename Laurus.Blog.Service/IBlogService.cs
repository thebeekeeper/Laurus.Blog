using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laurus.Blog.Entity;

namespace Laurus.Blog.Service
{
    public interface IBlogService
    {
        IEnumerable<Laurus.Blog.Service.DataContract.Blog> ListBlogs();
        void CreateBlog(Laurus.Blog.Service.DataContract.Blog blog);
        void CreateEntry(Entry entry);
    }
}
