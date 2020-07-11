using BlueModasStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrdersByCustomer(int CustomerId);
        Task<int> AddOrder(Order order);
        Task<bool> UpdateOrder(Order order);
    }
}
