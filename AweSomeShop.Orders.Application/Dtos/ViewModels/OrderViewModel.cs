using AweSomeShop.Orders.Core.Entities;
using AweSomeShop.Orders.Core.Enums;

namespace AweSomeShop.Orders.Application.Dtos.ViewModels
{
    public class OrderViewModel
    {

        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }


        public OrderViewModel(decimal totalPrice, DateTime createdAt, OrderStatus status)
        {
            this.TotalPrice = totalPrice;
            this.CreatedAt = createdAt;
            this.Status = status;

        }

        public static OrderViewModel FromEntity(Order order){
            
            return new OrderViewModel(order.TotalPrice,order.CreatedAt,order.Status);
        }

    }
}