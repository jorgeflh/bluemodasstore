using BlueModasStore.Domain.Interfaces.Repositories;
using BlueModasStore.Domain.Models;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemRepository itemRepository;

        public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            this.orderRepository = orderRepository;
            this.itemRepository = itemRepository;
        }

        public async Task<Order> AddItem(int productId, int? orderId, int quantity = 1)
        {
            Order order = new Order();
            Item item = new Item();
            bool itemAdded;

            if (!orderId.HasValue)
            {
                var id = await CreateOrder();
                item.OrderId = id;
                item.ProductId = productId;
                item.Quantity = quantity;
                itemAdded = await itemRepository.AddItem(item);

                if (!itemAdded)
                    return null;
            }

            order = await orderRepository.GetOrderById(orderId.Value);
            item.OrderId = orderId.Value;
            item.ProductId = productId;
            item.Quantity = quantity;
            itemAdded = await itemRepository.AddItem(item);

            if (!itemAdded)
                return null;

            return order;
        }

        public async Task<int> CreateOrder()
        {
            Order order = new Order
            {
                Status = Enum.OrderEnum.Open
            };

            return await orderRepository.AddOrder(order);
        }

        public async Task<bool> FinishOrder(int orderId, int customerId)
        {
            var order = await orderRepository.GetOrderById(orderId);
            order.CustomerId = customerId;
            order.Status = Enum.OrderEnum.Finished;
            return await orderRepository.UpdateStatus(order);
        }

        public async Task<bool> RemoveItem(int id)
        {
            return await itemRepository.RemoveItem(id);
        }

        public async Task<bool> UpdateItem(int id, int quantity)
        {
            var item = await itemRepository.GetItem(id);

            if (quantity > 0)
            {
                item.Quantity = quantity;
                return await itemRepository.UpdateItem(item);
            }
            else
                return await itemRepository.RemoveItem(id);
        }
    }
}
