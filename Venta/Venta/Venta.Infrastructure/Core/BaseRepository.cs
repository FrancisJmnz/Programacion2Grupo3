using System.Collections.Generic;
using Venta.Domain.Repository;

namespace Venta.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual List<TEntity> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public virtual TEntity GetEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Save(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
