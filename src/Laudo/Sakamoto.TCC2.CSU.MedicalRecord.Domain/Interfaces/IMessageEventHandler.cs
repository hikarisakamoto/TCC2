using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces
{
    public interface IMessageEventHandler
    {
        void SendMessage(StoredEvent storedEvent);
    }
}