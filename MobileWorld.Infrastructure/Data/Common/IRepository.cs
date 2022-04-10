﻿namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
