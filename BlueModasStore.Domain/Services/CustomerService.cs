using BlueModasStore.Domain.Interfaces.Repositories;
using BlueModasStore.Domain.Interfaces.Services;
using BlueModasStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<Customer> AddCustomer(Customer customer)
        {
            return customerRepository.AddCustomer(customer);
        }

        public Task<Customer> GetCustomerById(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        public Task<List<Customer>> GetCustomers()
        {
            return customerRepository.GetCustomers();
        }

        public Task<bool> RemoveCustomer(int id)
        {
            return customerRepository.RemoveCustomer(id);
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            return customerRepository.UpdateCustomer(customer);
        }
    }
}
