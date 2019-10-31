using System;
using System.Linq;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.Domain.Core.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        void Remove(Guid id);
        int SaveChanges();
        void Update(TEntity entity);
    }
}