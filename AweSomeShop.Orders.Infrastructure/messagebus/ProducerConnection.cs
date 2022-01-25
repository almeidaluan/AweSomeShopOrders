

using RabbitMQ.Client;

namespace AweSomeShop.Orders.Infrastructure.messagebus
{
    public class ProducerConnection
    {
        public IConnection Connection {get; set;}

        public ProducerConnection(IConnection connection){
            Connection = connection;
        }
    }
}