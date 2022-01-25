using System.Text;
using AweSomeShop.Orders.Core.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;

namespace AweSomeShop.Orders.Infrastructure.messagebus
{
    public class RabbitMQClient : IMessageBusClient
    {
        private readonly IConnection _connection;

        public RabbitMQClient(ProducerConnection producerConnection)
        {
            _connection = producerConnection.Connection;
        }
        public void Publish(object message, string routingKey, string exchange)
        {
            var channel = _connection.CreateModel();

            try
            {

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var payload = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(payload);

                channel.ExchangeDeclare(exchange, "direct", true);
                channel.BasicPublish(exchange, routingKey, null, body);
            }catch(Exception e){
                throw e;
            }
            finally
            {
                channel.Close();       
            }
        }
    }
}