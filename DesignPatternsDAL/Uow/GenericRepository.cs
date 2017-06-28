using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDAL.Uow
{

        public class GenericRepository<TEntity> where TEntity : class
        {
            internal DbContext _context;
            internal DbSet<TEntity> _dbSet;

            public GenericRepository(DbContext context)
            {
                _context = context;
                _context.Configuration.ProxyCreationEnabled = false;
                _dbSet = context.Set<TEntity>();


            }

            public virtual IQueryable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
            {
                IQueryable<TEntity> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }
                else
                {
                    return query;
                }
            }

            public virtual TEntity GetByID(object id)
            {
                return _dbSet.Find(id);
            }

            public virtual void Insert(TEntity entity)
            {
                _dbSet.Add(entity);
            }

            public virtual void Delete(object id)
            {
                TEntity entityToDelete = _dbSet.Find(id);
                Delete(entityToDelete);
            }

            public virtual void Delete(TEntity entityToDelete)
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            }

            public virtual void Update(TEntity entityToUpdate)
            {
                _dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }
}
