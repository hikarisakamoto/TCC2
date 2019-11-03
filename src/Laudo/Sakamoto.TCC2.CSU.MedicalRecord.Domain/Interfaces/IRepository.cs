using System;
using System.Threading.Tasks;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity medicalReport);
        Task<TEntity> GetById(Guid id);
        void Remove(Guid id);
    }
}