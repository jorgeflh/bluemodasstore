using BlueModasStore.Domain.Interfaces.Repositories;
using BlueModasStore.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IConfiguration config;

        public CustomerRepository(IConfiguration config)
        {
            this.config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("SqlServer"));
            }
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = @"INSERT INTO Customer(Name, Email, Phone) 
                               OUTPUT INSERTED.Id
                               VALUES (@Name, @Email, @Phone)";

                conn.Open();
                var id = await conn.QuerySingleAsync<int>(sql, new
                {
                    customer.Name,
                    customer.Email,
                    customer.Phone
                });

                customer.Id = id;
                return customer;
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Customer WHERE Id = @Id";
                conn.Open();
                var result = await conn.QueryAsync<Customer>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Customer>> GetCustomers()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Customer";
                conn.Open();
                var result = await conn.QueryAsync<Customer>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> RemoveCustomer(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "DELETE FROM Customer WHERE Id = @Id";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new { Id = id });

                if (result > 0)
                    return true;
            }

            return false;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "UPDATE Customer " +
                             "SET Name = @Name, @Phone " +
                             "WHERE Id = @Id";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new
                {
                    customer.Id,
                    customer.Name,
                    customer.Phone
                });

                if (result > 0)
                    return true;
            }

            return false;
        }
    }
}
