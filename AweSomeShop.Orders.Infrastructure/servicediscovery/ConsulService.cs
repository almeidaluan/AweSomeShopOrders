using Consul;

namespace AweSomeShop.Orders.Infrastructure.servicediscovery
{
    public class ConsulService : IServiceDiscoveryService
    {
        private readonly IConsulClient consulClient;


        public ConsulService(IConsulClient consulClient)
        {
            this.consulClient = consulClient;
        }
        public async Task<Uri> GetServiceUri(string serviceName, string requestUrl)
        {
            AgentService? service;
            
            var allRegisteredService = await consulClient.Agent.Services();

            var registeredServices = allRegisteredService.Response?.Where(s => s.Value.Service.Equals(serviceName,StringComparison.OrdinalIgnoreCase))
            .Select( s => s.Value)
            .ToList();

            if(registeredServices != null){
                  service = registeredServices.First();
            }else{
                throw new Exception("O service do consul esta nullo");
            }

            Console.WriteLine(service.Address);

            var uri = $"http://{service.Address}:{service.Port}/{requestUrl}";

            Console.WriteLine(uri);

            return new Uri(uri);
        }
    }
}