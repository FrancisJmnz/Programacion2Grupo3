
using System.Collections.Generic;

namespace Venta.Domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class //generics
    {
        //Metodos a Utilizar
        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetEntity(int id);
        List<TEntity> GetEntities();
    }
}
