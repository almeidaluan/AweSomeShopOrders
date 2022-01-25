using AweSomeShop.Orders.Core.Entities;
using AweSomeShop.Orders.Core.ValueObjects;
using MediatR;

namespace AweSomeShop.Orders.Application.Commands
{
    public class AddOrderCommand : IRequest<Guid>{
        

        public CustomerInputViewModel Customer { get; set;}
        public List<OrderItemInputModel> OrderItems { get; set;}
        public DeliveryAddressInputModel DeliveryAddress { get; set;}
        public PaymentAddressInputModel PaymentAddress { get; set;}
        public PaymentInfoInputModel PaymentInfo { get; set;}


        public AddOrderCommand(CustomerInputViewModel customer, List<OrderItemInputModel> orderItems, DeliveryAddressInputModel deliveryAddress, PaymentAddressInputModel paymentAddress, PaymentInfoInputModel paymentInfo)
        {
            Customer = customer;
            OrderItems = orderItems;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
        }

         public Order toEntity(){
            return new Order(
                new Customer(Customer.FullName, Customer.Email),
                new DeliveryAddress(DeliveryAddress.Street, DeliveryAddress.Number, DeliveryAddress.City, DeliveryAddress.State, DeliveryAddress.ZipCode),
                new PaymentAddress(PaymentAddress.Street, PaymentAddress.Number, PaymentAddress.City, PaymentAddress.State, PaymentAddress.ZipCode),
                new PaymentInfo(PaymentInfo.CardNumber,PaymentInfo.FullName,PaymentInfo.ExpirationDate,PaymentInfo.Cvv),
                OrderItems.Select( i => new OrderItem(i.ProductId,i.Quantity,i.Price)).ToList(),
                new DateTime()
            );
        }
    }

    public class CustomerInputViewModel{

        public Guid Id { get; set;}

        public string FullName { get; set;}

        public string Email {get; set;}
    }

    public class OrderItemInputModel {

        public Guid ProductId { get; set;}

        public int Quantity { get; set;}

        public decimal Price { get; set;}
        
    }

    public class DeliveryAddressInputModel{
        public string Street {get; set;}

        public string Number {get; set;}

        public string City {get; set;}

        public string State { get; set;}

        public string ZipCode { get; set;}
    }

    public class PaymentAddressInputModel {
        public string Street {get; set;}

        public string Number {get; set;}

        public string City {get; set;}

        public string State { get; set;}

        public string ZipCode { get; set;}
    }

    public class PaymentInfoInputModel {
        
        public string CardNumber { get; set;}

        public string FullName { get; set;}

        public string ExpirationDate { get; set;}
        public string Cvv { get; set;}

    }
}
