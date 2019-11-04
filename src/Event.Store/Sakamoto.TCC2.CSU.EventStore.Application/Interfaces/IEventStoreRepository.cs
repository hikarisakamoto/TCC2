using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Interfaces
{
    public interface IEventStoreRepository
    {
        void Save<T>(T theEvent) where T : Event;

    }
}