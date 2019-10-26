using System;
using Microsoft.EntityFrameworkCore.Storage;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PractitionerContext _context;
        private IDbContextTransaction _dbContextTransaction;
        private bool _disposed;

        public UnitOfWork(PractitionerContext context, IDbContextTransaction dbContextTransaction)
        {
            _context = context;
            _dbContextTransaction = dbContextTransaction;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Signals the beginning
        /// </summary>
        public void Begin()
        {
            _disposed = false;
            _dbContextTransaction = null;
        }

        /// <summary>
        ///     Saves changes in context (SaveChanges) and, if there is an open transaction, commits as well.
        /// </summary>
        /// <returns>True if there was any entity changed or false if there wasn't</returns>
        public bool Commit()
        {
            if (_context.SaveChanges() <= 0) return false;

            _dbContextTransaction?.Commit();
            return true;
        }

        /// <summary>
        ///     Discard changes in context (DiscardChanges) and, if there is an open transaction, do the Rollback as well.
        /// </summary>
        public void Rollback()
        {
            _context.DiscardChanges();
            _dbContextTransaction?.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContextTransaction?.Dispose();
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}