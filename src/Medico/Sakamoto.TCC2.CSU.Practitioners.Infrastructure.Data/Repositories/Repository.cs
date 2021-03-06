﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly PractitionerContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(PractitionerContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}