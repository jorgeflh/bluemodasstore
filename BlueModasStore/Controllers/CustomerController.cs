using BlueModasStore.Domain.Interfaces.Services;
using BlueModasStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlueModasStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("IdentifyCustomer")]
        public async Task<Customer> IdentifyCustomer([FromBody] JsonElement data)
        {
            Customer customer = new Customer
            {
                Name = data.GetProperty("name").GetString(),
                Email = data.GetProperty("email").GetString(),
                Phone = data.GetProperty("phone").GetString()
            };
            return await customerService.AddCustomer(customer);
        }
    }
}
