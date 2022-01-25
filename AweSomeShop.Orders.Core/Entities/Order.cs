using System;
using System.Collections.Generic;
using AweSomeShop.Orders.Core.ValueObjects;
using System.Linq;
using AweSomeShop.Orders.Core.Events;
using AweSomeShop.Orders.Core.Enums;

namespace AweSomeShop.Orders.Core.Entities
{
    public class Order : AggregateRoot
    {

        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }

        public DeliveryAddress DeliveryAddress { get; set; }

        public PaymentAddress PaymentAddress { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

        public List<OrderItem> Items { get; set; }

        public DateTime CreatedAt { get; set; }

        public OrderStatus Status { get; set;}

        public Order(Customer customer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress, PaymentInfo paymentInfo,List<OrderItem> items ,DateTime createdAt)
        {
            this.TotalPrice = items.Sum( item => item.Quantity * item.Price);
            this.Customer = customer;
            this.DeliveryAddress = deliveryAddress;
            this.PaymentAddress = paymentAddress;
            this.PaymentInfo = paymentInfo;
            this.CreatedAt = DateTime.Now;
            this.Items = items;
            this.Status = OrderStatus.Started;

            AddEvent(new OrderCreated(Id,TotalPrice,PaymentInfo,Customer.FullName,Customer.Email));

        }

        public void SetAsCompleted(){
            Status = OrderStatus.Completed;
        }

        public void SetAsReject(){
            Status = OrderStatus.Rejected;
        }
    }
}