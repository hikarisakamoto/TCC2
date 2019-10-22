using System;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces
{
    /// <summary>
    ///     Unit Of Work pattern, maintains a list of objects affected by a transaction, coordinates change writing, and
    ///     addresses potential concurrency issues.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>Signalizes the beginning of  </summary>
        void Begin();

        /// <summary>Commits changes in the context (SaveChanges).</summary>
        bool Commit();

        /// <summary>Rollback changes made in the context (DiscardChanges).</summary>
        void Rollback();
    }
}