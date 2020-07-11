using BlueModasStore.Domain.Interfaces.Services;
using BlueModasStore.Domain.Models;
using BlueModasStore.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlueModasStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<Order> AddItem([FromBody] JsonElement data)
        {
            int productId = data.GetProperty("productId").GetInt32();
            int orderId = data.GetProperty("orderId").GetInt32();
            int quantity = data.GetProperty("quantity").GetInt32();

            return await orderService.AddItem(productId, orderId, quantity);
        }

        [HttpGet]
        [Route("GetOrder/{id}")]
        public async Task<OrderCartViewModel> GetOrder(int id)
        {
            if (id == 0)
                return null;

            return await orderService.GetOrder(id);
        }

        [HttpPost]
        [Route("UpdateItem")]
        public async Task<bool> UpdateItem([FromBody] dynamic data)
        {
            int itemId = data.GetProperty("itemId").GetInt32();
            int quantity = data.GetProperty("quantity").GetInt32();
            return await orderService.UpdateItem(itemId, quantity);
        }

        [HttpPost]
        [Route("RemoveItem")]
        public async Task<bool> RemoveItem([FromBody] dynamic data)
        {
            int itemId = data.GetProperty("itemId").GetInt32();
            return await orderService.RemoveItem(itemId);
        }

        [HttpPost]
        [Route("FinishOrder")]
        public async Task<bool> FinishOrder([FromBody] dynamic data)
        {
            int orderId = data.GetProperty("orderId").GetInt32();
            int customerId = data.GetProperty("customerId").GetInt32();
            return await orderService.FinishOrder(orderId, customerId);
        }
    }
}
