using System;
using AweSomeShop.Orders.Core.Entities;
using AweSomeShop.Orders.Core.ValueObjects;

namespace AweSomeShop.Orders.Core.Events
{
    public class OrderCreated : IDomainEvent
    {
        private Guid id;
        private decimal totalPrice;
        private PaymentInfo paymentInfo;
        private string fullName;
        private string email;

        public OrderCreated(Guid id, decimal totalPrice, PaymentInfo paymentInfo, string fullName, string email)
        {
            this.id = id;
            this.totalPrice = totalPrice;
            this.paymentInfo = paymentInfo;
            this.fullName = fullName;
            this.email = email;
        }
    }
}