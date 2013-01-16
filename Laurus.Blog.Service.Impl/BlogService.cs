using Laurus.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Blog.Service.Impl
{
    public class BlogService : IBlogService
    {
        public BlogService(IRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<Laurus.Blog.Service.DataContract.Blog> IBlogService.ListBlogs()
        {
            var blogs = from x in _repository.Query<Entity.Blog>()
                        select new DataContract.Blog()
                        {
                            Title = x.Title,
                            Id = x.Id
                        };
            return blogs.ToList();
        }

        void IBlogService.CreateBlog(Laurus.Blog.Service.DataContract.Blog blog)
        {
            var entity = new Entity.Blog()
            {
                Title = blog.Title,
                Id = blog.Id
            };
            _repository.Persist(entity);
        }

        void IBlogService.CreateEntry(Entity.Entry entry)
        {
            _repository.Persist(entry);
        }

        private IRepository _repository;
    }
}
