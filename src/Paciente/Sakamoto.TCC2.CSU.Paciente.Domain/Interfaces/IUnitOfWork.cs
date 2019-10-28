using System;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Interfaces
{
    /// <summary>
    ///     Unit Of Work pattern, maintains a list of objects affected by a transaction, coordinates change writing, and
    ///     addresses potential concurrency issues.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Signalizes the beginning
        /// </summary>
        void Begin();

        /// <summary>
        ///     Signals the start and opens a transaction in the database.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        ///     Commits changes in the context (SaveChanges).
        /// </summary>
        bool Commit();

        /// <summary>
        ///     Rollback changes made in the context (DiscardChanges).
        /// </summary>
        void Rollback();
    }
}