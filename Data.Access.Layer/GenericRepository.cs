using Data.Access.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {   
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public T Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
            }
            _db.Remove(entity);
            return entity;
        }

        public IEnumerable<T> DeleteRange(IEnumerable<T> entities)
        {
            if (_context.Entry(entities).State == EntityState.Detached)
            {
                _context.Attach(entities);
            }
            _db.RemoveRange(entities);
            return entities;
        }

        public T Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            return query.FirstOrDefault(expression);
        }

        public IList<T> Where(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }

            return query.Where(expression).ToList();
        }

        public IList<T> GetAll()
        {
            return _db.ToList();
        }

        public T Insert(T entity)
        {
            _db.Add(entity);
            return entity;
        }

        public IEnumerable<T> InsertRange(IEnumerable<T> entity)
        {
            _db.AddRange(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
