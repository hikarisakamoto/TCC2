using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.EventStore.Application.Configurations;
using Sakamoto.TCC2.CSU.EventStore.Application.Interfaces;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Services
{
    public class RabbitMQHostedService : BackgroundService
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private IModel _channel;
        private IConfiguration _configuration;
        private IConnection _connection;

        public RabbitMQHostedService(ILoggerFactory loggerFactory, IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
            InitRabbitMQ();
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                // received message  
                var content = Encoding.UTF8.GetString(ea.Body);

                // handle the received message  
                HandleMessage(content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume("CSU", false, consumer);
            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {
            var message = JsonConvert.DeserializeObject<StoredEvent>(content);
            _eventStoreRepository.Save(message);
        }

        private void InitRabbitMQ()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            var rabbitMQConfigurations = new RabbitMQConfigurations();
            new ConfigureFromConfigurationOptions<RabbitMQConfigurations>(
                    _configuration.GetSection("RabbitMQConfigurations"))
                .Configure(rabbitMQConfigurations);

            var factory = new ConnectionFactory
            {
                HostName = rabbitMQConfigurations.HostName,
                Port = rabbitMQConfigurations.Port,
                UserName = rabbitMQConfigurations.UserName,
                Password = rabbitMQConfigurations.Password
            };

            // create connection  
            _connection = factory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();

            //_channel.ExchangeDeclare("CSU.exchange", ExchangeType.Topic);
            //_channel.QueueDeclare("demo.queue.log", false, false, false, null);
            //_channel.QueueBind("demo.queue.log", "demo.exchange", "demo.queue.*", null);
            //_channel.BasicQos(0, 1, false);

            //_connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

            _channel.QueueDeclare("CSU",
                false,
                false,
                false,
                null);
        }

        private static void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private static void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private static void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private static void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }
    }
}