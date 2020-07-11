using BlueModasStore.Domain.Interfaces.Repositories;
using BlueModasStore.Domain.Models;
using BlueModasStore.Domain.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemRepository itemRepository;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public OrderService(
            IOrderRepository orderRepository, 
            IItemRepository itemRepository,
            IProductService productService,
            ICustomerService customerService)
        {
            this.orderRepository = orderRepository;
            this.itemRepository = itemRepository;
            this.productService = productService;
            this.customerService = customerService;
        }

        public async Task<Order> AddItem(int productId, int orderId = 0, int quantity = 1)
        {
            Order order = new Order();
            Item item = new Item();
            bool itemAdded;

            if (orderId == 0)
            {
                orderId = await CreateOrder();
                item.OrderId = orderId;
                item.ProductId = productId;
                item.Quantity = quantity;
                itemAdded = await itemRepository.AddItem(item);

                if (!itemAdded)
                    return null;

                order = await orderRepository.GetOrderById(orderId);
            }
            else
            {
                order = await orderRepository.GetOrderById(orderId);

                var itemExist = order.Items.Where(x => x.ProductId == productId).FirstOrDefault();

                if (itemExist == null)
                {
                    item.OrderId = order.Id;
                    item.ProductId = productId;
                    item.Quantity = quantity;
                    itemAdded = await itemRepository.AddItem(item);

                    if (!itemAdded)
                        return null;
                }
                else
                {
                    itemExist.Quantity += quantity;
                    _ = await itemRepository.UpdateItem(itemExist);
                }
            }

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
            return await orderRepository.UpdateOrder(order);
        }

        public async Task<OrderCartViewModel> GetOrder(int id)
        {
            var order = await orderRepository.GetOrderById(id);
            Customer customer = new Customer();

            if (order.CustomerId != 0)
            {
                customer = await customerService.GetCustomerById(order.CustomerId);
            }

            var orderCartViewModel = new OrderCartViewModel
            {
                Id = order.Id,
                Status = order.Status,
                Items = new List<ItemCartViewModel>(),
            };

            if (customer != null)
                orderCartViewModel.Customer = customer;

            foreach(var item in order.Items)
            {
                var itemCartViewModel = new ItemCartViewModel();
                var product = await productService.GetProductById(item.ProductId);
                itemCartViewModel.Id = item.Id;
                itemCartViewModel.OrderId = item.OrderId;
                itemCartViewModel.ProductId = product.Id;
                itemCartViewModel.ProductName = product.Name;
                itemCartViewModel.ProductPrice = product.Price;
                itemCartViewModel.ProductImage = product.Image;
                itemCartViewModel.Quantity = item.Quantity;

                orderCartViewModel.Total += product.Price * item.Quantity;

                orderCartViewModel.Items.Add(itemCartViewModel);
            }

            return orderCartViewModel;
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
