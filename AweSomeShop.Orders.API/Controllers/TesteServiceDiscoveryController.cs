using AweSomeShop.Orders.Infrastructure.servicediscovery;
using Microsoft.AspNetCore.Mvc;

namespace AweSomeShop.Orders.API.Controllers
{
    [ApiController()]
    [Route("teste")]
    public class TesteServiceDiscoveryController
    {
        

        private readonly IServiceDiscoveryService serviceDiscovery;


        public TesteServiceDiscoveryController(IServiceDiscoveryService serviceDiscovery)
        {
            this.serviceDiscovery = serviceDiscovery;
        }


        [HttpGet("saudacao")]
        public string Hello(){
            return "oi tudo bem!!!";
        }

        [HttpGet("chamasaudacao")]
        public async Task<Uri> ChamaSaudacao(){
            var saudacaoUrl = await serviceDiscovery.GetServiceUri("OrderServicesApi","saudacao");
            return saudacaoUrl;
        }
    }
}