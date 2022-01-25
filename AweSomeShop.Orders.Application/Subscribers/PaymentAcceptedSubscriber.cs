using System.Text;
using AweSomeShop.Orders.Core.Entities;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AweSomeShop.Orders.Application.Subscribers
{
    public class PaymentAcceptedSubscriber : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IConnection connection;
        private readonly IModel channel;

        public PaymentAcceptedSubscriber(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory{
                HostName = "localhost"
            };

            connection = connectionFactory.CreateConnection("order-service-payment-accepted-subscriber");

            channel = connection.CreateModel();

            channel.QueueDeclare("payment-accepted",true,false,false,null);
            channel.QueueBind("payment-accepted","payment-service","payment-accepted-rountingkey");
        }

         protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (sender,EventArgs) => {
                var byteArray = EventArgs.Body.ToArray();

                var contentString = Encoding.UTF8.GetString(byteArray);

                var message = JsonConvert.DeserializeObject<List<Order>>(contentString);
                
                Console.WriteLine($"Mensagem recebida - {message.Count}");

                channel.BasicAck(EventArgs.DeliveryTag,true);
            };

            channel.BasicConsume("payment-accepted",false,consumer);
            
            return Task.CompletedTask;
        }
    }
}