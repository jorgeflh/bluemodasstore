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
    public class ItemRepository : IItemRepository
    {
        private readonly IConfiguration config;

        public ItemRepository(IConfiguration config)
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

        public async Task<bool> AddItem(Item item)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "INSERT INTO Item(OrderId, ProductId, Quantity) " +
                             "VALUES(@OrderId, @ProductId, @Quantity)";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new
                {
                    item.OrderId,
                    item.ProductId,
                    item.Quantity
                });

                if (result > 0)
                    return true;
            }

            return false;
        }

        public async Task<Item> GetItem(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Item WHERE Id = @Id";
                conn.Open();
                var result = await conn.QueryAsync<Item>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Item>> GetItems(int orderId)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Item WHERE OrderId = @OrderId";
                conn.Open();
                var result = await conn.QueryAsync<Item>(sql, new { OrderId = orderId });
                return result.ToList();
            }
        }

        public async Task<bool> RemoveItem(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "DELETE FROM Item WHERE Id = @Id";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new { Id = id });

                if (result > 0)
                    return true;
            }

            return false;
        }
    }
}
