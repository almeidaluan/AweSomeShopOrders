using AweSomeShop.Orders.Application.Dtos.ViewModels;
using AweSomeShop.Orders.Core.Entities;
using AweSomeShop.Orders.Core.interfaces;
using AweSomeShop.Orders.Core.Repositories;
using MediatR;

namespace AweSomeShop.Orders.Application.Queries.handles
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderDetailByIdQueries, OrderViewModel>
    {

        private readonly IOrderRepository _orderRepository;

        private readonly IMessageBusClient messageBus;

        private readonly ICacheService cacheService;
        public GetOrderByIdHandler(IOrderRepository orderRepository,IMessageBusClient messageBusClient,ICacheService cacheService){
            this._orderRepository = orderRepository;
            this.messageBus = messageBusClient;
            this.cacheService = cacheService;
        }

        public async Task<OrderViewModel> Handle(GetOrderDetailByIdQueries request, CancellationToken cancellationToken)
        {
            var cacheKey = request.Id.ToString();
            
            var orderViewModelCache = await cacheService.GetAsync<OrderViewModel>(cacheKey);
            
            if(orderViewModelCache == null){
                var order = await _orderRepository.GetByIdAsync(request.Id);
                
                orderViewModelCache = OrderViewModel.FromEntity(order);

                await cacheService.SetAsync(cacheKey, orderViewModelCache);

            }

            // var listaOrders = new List<Order>();
            
            // for (int i = 1; i <=10000; i++)
            // {
            //   listaOrders.Add(order);
            // }
            
            // this.messageBus.Publish(listaOrders,"order-find-rountingkey","payment-service"); 

            return orderViewModelCache;

        }
    }
}