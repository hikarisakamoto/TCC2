using System;
using System.Linq;
using Sakamoto.TCC2.CSU.Domain.Core.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(Guid id);
        int SaveChanges();
    }
}