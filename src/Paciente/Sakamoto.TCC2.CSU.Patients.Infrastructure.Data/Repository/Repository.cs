using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly PatientContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(PatientContext context, DbSet<TEntity> dbSet)
        {
            Context = context;
            DbSet = dbSet;
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}