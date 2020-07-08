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
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration config;

        public OrderRepository(IConfiguration config)
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

        public async Task<int> AddOrder(Order order)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "INSERT INTO Order(CustomerId, Status) " +
                             "VALUES(@CustomerId, @Status)";
                conn.Open();
                var id = await conn.QuerySingleAsync<int>(sql, new
                {
                    order.CustomerId,
                    order.Status
                });

                return id;
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Order WHERE Id = @Id";
                conn.Open();
                var result = await conn.QueryAsync<Order>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Order>> GetOrdersByCustomer(int CustomerId)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Order WHERE CustomerId = @CustomerId";
                conn.Open();
                var result = await conn.QueryAsync<Order>(sql, new { CustomerId });
                return result.ToList();
            }
        }

        public async Task<bool> UpdateStatus(Order order)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "UPDATE Order " +
                             "SET Status = @Status " +
                             "WHERE Id = @Id";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new
                {
                    order.Id,
                    order.Status
                });

                if (result > 0)
                    return true;
            }

            return false;
        }
    }
}
