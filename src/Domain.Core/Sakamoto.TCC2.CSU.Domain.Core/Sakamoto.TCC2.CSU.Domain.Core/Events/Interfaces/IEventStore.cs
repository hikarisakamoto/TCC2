namespace Sakamoto.TCC2.CSU.Domain.Core.Events.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T @event) where T : Event;
    }
}