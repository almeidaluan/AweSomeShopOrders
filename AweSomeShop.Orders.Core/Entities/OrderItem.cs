using System;

namespace AweSomeShop.Orders.Core.Entities
{
    public class OrderItem: Entity
    {
        public Guid ProductId { get; set;}
        public int Quantity { get; set;}
        public decimal Price { get; set;}

        public OrderItem(Guid productId, int quantity, decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}