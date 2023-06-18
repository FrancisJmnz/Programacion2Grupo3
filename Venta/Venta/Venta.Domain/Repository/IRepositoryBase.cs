using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Venta.Domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void SaveChanges();
        void Update(TEntity entity);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetEntity(int id);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetEntities();
    }
}
