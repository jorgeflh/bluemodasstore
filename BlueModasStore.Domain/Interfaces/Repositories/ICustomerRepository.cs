using BlueModasStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomers();
        Task<Customer> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> RemoveCustomer(int id);
    }
}
