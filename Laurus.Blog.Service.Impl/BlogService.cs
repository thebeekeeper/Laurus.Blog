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

        int IBlogService.CreateBlog(Laurus.Blog.Service.DataContract.Blog blog)
        {
            var entity = new Entity.Blog()
            {
                Title = blog.Title,
                Id = blog.Id
            };
            _repository.Persist(entity);
			return entity.Id;
        }

        int IBlogService.CreateEntry(DataContract.Entry entry)
        {
			var entity = new Entity.Entry()
			{
				Content = entry.Content,
				Name = entry.Title,
				Id = new Random().Next(1000)
			};
			return entity.Id;
        }

		void IBlogService.AddEntry(DataContract.Blog blog, DataContract.Entry entry)
		{
			var blogEntity = new Entity.Blog()
			{
				Title = blog.Title,
				Id = blog.Id
			};
			var entryEntity = new Entity.Entry()
			{
				Name = entry.Title,
				Content = entry.Content
			};
			blogEntity.Entries.Concat(new[] { entryEntity });
		}

		IEnumerable<DataContract.Entry> IBlogService.GetAllEntries()
		{
			return from e in _repository.Query<Entity.Entry>().ToList()
				   select new DataContract.Entry()
				   {
					   Title = e.Name,
					   Content = e.Content,
				   };
		}

		DataContract.Blog IBlogService.GetBlog(int id)
		{
			var entity = _repository.Read<Entity.Blog>(id);
			return new DataContract.Blog()
			{
				Title = entity.Title,
				Id = entity.Id
			};
		}

        private IRepository _repository;
    }
}
