﻿using System;
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
        int CreateBlog(Laurus.Blog.Service.DataContract.Blog blog);
		int CreateEntry(DataContract.Entry entry);
		void AddEntry(int blogId, DataContract.Entry entry);
		IEnumerable<DataContract.Entry> GetAllEntries();
		DataContract.Blog GetBlog(int id);
		IEnumerable<DataContract.Entry> GetEntriesForBlog(int blogId);
    }
}
