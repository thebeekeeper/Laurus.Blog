using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Components.Impl
{
    public class DefaultRepository : IRepository
    {
        public DefaultRepository()
        {
            _db = new Dictionary<int, object>();
        }

        T IRepository.Read<T>(int id) 
        {
            return _db.Where(x => x.Key == id).Cast<T>().FirstOrDefault();
        }

        IQueryable<T> IRepository.Query<T>()
        {
            return _db.Values.Where(x => x.GetType() == typeof(T)).Cast<T>().AsQueryable();
        }

        int IRepository.Persist<T>(T entity)
        {
            int id = 0;
            _db[id] = entity;
            return id;
        }

        private IDictionary<int, object> _db;
    }
}
