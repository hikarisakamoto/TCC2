using System;
using System.Linq;
using Sakamoto.TCC2.CSU.Domain.Core.Models;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Remove(Guid id);
        int SaveChanges();
        void Update(TEntity entity);
    }
}