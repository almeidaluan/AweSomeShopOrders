using System;
using System.Threading.Tasks;
using AweSomeShop.Orders.Core.Entities;

namespace AweSomeShop.Orders.Core.Repositories
{
    public interface IOrderRepository
    {
         Task<Order> GetByIdAsync(Guid id);
         Task AddAsync(Order order);
         Task UpdateAsync(Order order);
    }
}