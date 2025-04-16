using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer
{
    public interface IRepository<T> where T : class
    {
        //Expression<Func<T, bool>> expression = null,
        //Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //List<string> includes = null
        IList<T> GetAll();
        T Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        IList<T> Where(Expression<Func<T, bool>> expression, List<string> includes = null);
        T Insert(T entity);
        IEnumerable<T> InsertRange(IEnumerable<T> entity);
        T Delete(T entity);
        IEnumerable<T> DeleteRange(IEnumerable<T> entities);
        T Update(T entity);
    }
}
