using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ByteXecom.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IList<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        //Remove more than one entity at a time
        void RemoveRange(IEnumerable<T> entities);
        
    }
}
