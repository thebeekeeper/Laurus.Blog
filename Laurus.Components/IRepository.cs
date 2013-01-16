using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Components
{
    public interface IRepository
    {
        T Read<T>(int id);
        IQueryable<T> Query<T>();
        int Persist<T>(T entity);
    }
}
