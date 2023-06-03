using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetEntity(int id);
        List<TEntity> GetEntities();
    }
}
