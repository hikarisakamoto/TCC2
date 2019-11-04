using System;
using System.Collections.Generic;
using Sakamoto.TCC2.CSU.EventStore.Application.Models;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Interfaces
{
    public interface IEventStoreRepository
    {
        IList<StoredEvents> All(Guid aggregateId);
        void Save(StoredEvents theEvent);
    }
}