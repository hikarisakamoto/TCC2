using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.Domain.Core.Commands;
using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : Event;
        Task SendCommand<T>(T command) where T : Command;
    }
}