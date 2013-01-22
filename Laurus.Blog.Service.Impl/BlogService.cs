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
            var blogs = (from x in _repository.Query<Entity.Blog>()
                        select new DataContract.Blog()
                        {
                            Title = x.Title,
                            Id = x.Id
                        }).ToList();
			return blogs;
        }

        int IBlogService.CreateBlog(Laurus.Blog.Service.DataContract.Blog blog)
        {
            var entity = new Entity.Blog()
            {
                Title = blog.Title,
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

		void IBlogService.AddEntry(int blogId, DataContract.Entry entry)
		{
			var entryEntity = new Entity.Entry()
			{
				Name = entry.Title,
				Content = entry.Content,
				BlogId = blogId
			};
			_repository.Persist(entryEntity);
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

		IEnumerable<DataContract.Entry> IBlogService.GetEntriesForBlog(int blogId)
		{
			return from b in _repository.Query<Entity.Entry>().Where(e => e.BlogId == blogId)
				   select new DataContract.Entry()
				   {
					   Title = b.Name,
					   Content = b.Content
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
