using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Venta.Domain.Repository
{
        public interface IRepositoryBase<TEntity> where TEntity : class
        {
        void Update(TEntity entity);
        void SaveChanges();
        void Remove(TEntity entity);
        void Add(TEntity entity);
        TEntity GetEntity(int id);
        bool Exists(Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetEntities();
    }
}