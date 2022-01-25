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

        public GetOrderByIdHandler(IOrderRepository orderRepository,IMessageBusClient messageBusClient){
            this._orderRepository = orderRepository;
            this.messageBus = messageBusClient;
        }

        public async Task<OrderViewModel> Handle(GetOrderDetailByIdQueries request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if(order == null){
                return null;
            }
            var orderViewModel = OrderViewModel.FromEntity(order);
            
            var listaOrders = new List<Order>();
            
            for (int i = 1; i <=10000; i++)
            {
              listaOrders.Add(order);
            }
            
            this.messageBus.Publish(listaOrders,"order-find-rountingkey","payment-service"); 

            return orderViewModel;

        }
    }
}