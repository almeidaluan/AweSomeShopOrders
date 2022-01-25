namespace AweSomeShop.Orders.Infrastructure.servicediscovery
{
    public interface IServiceDiscoveryService
    {
         Task<Uri> GetServiceUri(string serviceName, string requestUrl);
    }
}