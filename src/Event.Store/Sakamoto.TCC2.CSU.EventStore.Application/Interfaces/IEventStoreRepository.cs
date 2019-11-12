using System;
using System.Collections.Generic;
using Sakamoto.TCC2.CSU.EventStore.Application.Models;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Interfaces
{
    public interface IEventStoreRepository
    {
        IEnumerable<Guid> All();
        IList<StoredEvents> EventsByAggregate(Guid aggregateId);
        void Save(StoredEvents theEvent);
    }
}