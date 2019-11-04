using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus.Configurations;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus.Handler
{
    public class MessageEventHandler : IMessageEventHandler
    {
        private readonly IConnectionFactory _connectionFactory;

        public MessageEventHandler(IMessageConfigurations messageConfigurations)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = messageConfigurations.HostName,
                Port = messageConfigurations.Port,
                UserName = messageConfigurations.UserName,
                Password = messageConfigurations.Password
            };
        }

        public void SendMessage(StoredEvent storedEvent)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("CSU",
                false,
                false,
                false,
                null);

            var message = JsonConvert.SerializeObject(storedEvent);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("",
                "CSU",
                null,
                body);
        }
    }
}