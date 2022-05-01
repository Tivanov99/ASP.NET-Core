﻿namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IRepository
    {
        Task<TEntity?> GetByIdAsync<TEntity>(object id) where TEntity : class;

        IQueryable GetAsQueryable<TEntity>() where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        TEntity? GetById<TEntity>(object id) where TEntity : class;

        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity id) where TEntity : class;

        Task DeleteAsync<TEntity>(TEntity id) where TEntity : class;

    }
}
