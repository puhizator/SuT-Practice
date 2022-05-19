using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DBTesting.Utils
{
    public class BaseClient<TContext, TEntity> where TContext : DbContext where TEntity : class, new()
    {
        private readonly DbContext context;

        public BaseClient(string connectionString)
        {
            context = (TContext)Activator.CreateInstance(
                typeof(TContext),
                new DbContextOptionsBuilder<TContext>().UseMySql(connectionString).Options);
        }

        public TEntity Get(params object[] primaryKeys)
        {
            var entity = context.Set<TEntity>().Find(primaryKeys);

            if (entity == null)

                throw new InvalidOperationException($"{typeof(TEntity).Name} is not registered.");

            return entity;
        }

        public TEntity GetFirst()
        {
            var entity = context.Set<TEntity>().FirstOrDefault();
            if (entity == null)
                throw new InvalidOperationException($"{typeof(TEntity).Name} does not exist");

            return entity;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().AsNoTracking().Count(predicate);
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
        public void AddRange(IList<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = Get(id);
            context.Set<TEntity>().Remove(entityToDelete);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void Reload(TEntity entity)
        {
            context.Entry(entity).Reload();
        }

        // new methods


        public TEntity GetByCompositePrimaryKey(Expression<Func<TEntity, bool>> conditionLambda)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(conditionLambda);

            if (entity == null)
                throw new InvalidOperationException($"{typeof(TEntity).Name} with condition not found.");

            return entity;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> conditionLambda)
        {
            var entityToDelete = GetByCompositePrimaryKey(conditionLambda);
            context.Set<TEntity>().Remove(entityToDelete);
            context.SaveChanges();
        }

        public void DeleteRange(IReadOnlyCollection<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entityToDelete = Get(id);
            context.Set<TEntity>().Remove(entityToDelete);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entityToDelete = Get(id);
            context.Set<TEntity>().Remove(entityToDelete);
            context.SaveChanges();
        }

        public void AddRangeReadOnly(IReadOnlyCollection<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

    }
}
