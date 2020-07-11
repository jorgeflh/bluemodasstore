using BlueModasStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> RemoveCustomer(int id);
    }
}
