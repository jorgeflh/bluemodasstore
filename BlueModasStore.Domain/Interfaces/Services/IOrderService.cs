using BlueModasStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<int> CreateOrder();
        Task<Order> AddItem(int productId, int? orderId, int quantity = 1);
        Task<bool> UpdateItem(int id, int quantity);
        Task<bool> RemoveItem(int id);
        Task<bool> FinishOrder(int orderId, int customerId);
    }
}
