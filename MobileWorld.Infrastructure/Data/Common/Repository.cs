﻿using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace MobileWorld.Infrastructure.Data.Common
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> UseSqlRaw(string sqlCommand, object[] parameters)
        {
            return dbSet.FromSqlRaw(sqlCommand, parameters);
        }


        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

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
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return context.Set<TEntity>().AsQueryable();
        }
    }
}
