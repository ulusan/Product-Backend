using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext northwindContext = new TContext())
            {
                return filter == null
                    ? northwindContext.Set<TEntity>().ToList()
                    : northwindContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext northwindContext = new TContext())
            {
                return northwindContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext northwindContext = new TContext())
            {
                var addedEntity = northwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var updatedEntity = northwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext northwindContext = new TContext())
            {
                var deletedEntity = northwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }
    }
}
