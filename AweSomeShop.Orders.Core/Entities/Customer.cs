using System;

namespace AweSomeShop.Orders.Core.Entities
{
    public class Customer : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public Customer(string fullName, string email)
        {
            this.FullName = fullName;
            this.Email = email;

        }

    }
}