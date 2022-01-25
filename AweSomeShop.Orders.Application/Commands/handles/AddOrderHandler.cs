using AweSomeShop.Orders.Core.Entities;
using AweSomeShop.Orders.Core.interfaces;
using AweSomeShop.Orders.Core.Repositories;
using MediatR;

namespace AweSomeShop.Orders.Application.Commands.handles
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        public readonly IOrderRepository orderRepository;

        private readonly IMessageBusClient _messageBus;

        public AddOrderHandler(IOrderRepository orderRepository, IMessageBusClient messageBusClient)
        {
            this.orderRepository = orderRepository;
            this._messageBus = messageBusClient;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.toEntity();

            await orderRepository.AddAsync(order);
            
            var listaOrders = new List<Order>();

            for (int i = 1; i <=10000; i++)
            {
              listaOrders.Add(order);
            }
            
            _messageBus.Publish(listaOrders,"payment-accepted-rountingkey","payment-service"); 
            
            
            return order.Id;
        }
    }
}