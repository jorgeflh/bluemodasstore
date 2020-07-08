using BlueModasStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItem(int id);
        Task<List<Item>> GetItems(int orderId);
        Task<bool> AddItem(Item item);
        Task<bool> UpdateItem(Item item);
        Task<bool> RemoveItem(int id);
    }
}
