using AweSomeShop.Orders.Application.Dtos.ViewModels;
using MediatR;

namespace AweSomeShop.Orders.Application.Queries
{
    public class GetOrderDetailByIdQueries: IRequest<OrderViewModel>
    {

        public Guid Id { get; set;}

        public GetOrderDetailByIdQueries(Guid Id){
            this.Id = Id;
        }


        
    }
}