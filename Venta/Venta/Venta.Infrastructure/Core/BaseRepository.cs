using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Repository;

namespace Venta.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual List<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
