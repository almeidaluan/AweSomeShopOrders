namespace AweSomeShop.Orders.Core.interfaces
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey,string exchange);
    }
}