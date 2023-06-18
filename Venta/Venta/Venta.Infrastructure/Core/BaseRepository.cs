using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Venta.Domain.Repository;
using Venta.Infrastructure.Context;

namespace Venta.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly VentaContext context;
        private readonly DbSet<TEntity> myDbSet;

        public BaseRepository(VentaContext context)
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();
        }

        //METODO AÑADIR
        public virtual void Add(TEntity entity)
        {
            this.myDbSet.Add(entity);
        }

        //Comprobar si exite
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            
            return this.myDbSet.Any(filter);
        }
        //GETENTETY
        public virtual TEntity GetEntity(int id)
        {
            return this.myDbSet.Find(id);
        }

        //METODO REMOVER
        public virtual void Remove(TEntity entity)
        {
            this.myDbSet.Remove(entity);
        }

        //METODO GUARDAR
        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

        //METODO ACTUALIZAR
        public virtual void Update(TEntity entity)
        {
            this.myDbSet.Update(entity);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.myDbSet.ToList();
        }

        
    }
}
