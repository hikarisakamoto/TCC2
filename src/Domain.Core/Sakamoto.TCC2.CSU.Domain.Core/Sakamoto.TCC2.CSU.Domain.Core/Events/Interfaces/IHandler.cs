namespace Sakamoto.TCC2.CSU.Domain.Core.Events.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}