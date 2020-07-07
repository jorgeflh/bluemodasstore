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
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration config;

        public ProductRepository(IConfiguration config)
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

        public async Task<bool> AddProduct(Product product)
        {
            bool added = false;

            using (IDbConnection conn = Connection)
            {
                string sql = "INSERT INTO Product(Name, Price, Image) VALUES(@Name, @Price, @Image)";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new { product.Name, product.Price, product.Image });

                if (result > 0)
                    added = true;
            }

            return added;
        }

        public async Task<Product> GetProductById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Product WHERE Id = @Id";
                conn.Open();
                var result = await conn.QueryAsync<Product>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM Product";
                conn.Open();
                var result = await conn.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> RemoveProduct(int id)
        {
            bool deleted = false;

            using (IDbConnection conn = Connection)
            {
                string sql = "DELETE FROM Product WHERE Id = @Id";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new { Id = id });

                if (result > 0)
                    deleted = true;
            }

            return deleted;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            bool updated = false;

            using (IDbConnection conn = Connection)
            {
                string sql = "UPDATE Product " +
                             "SET Name = @Name, Price = @Price, Image = @Image " +
                             "WHERE Id = @Id";
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new { product.Id, product.Name, product.Price, product.Image });

                if (result > 0)
                    updated = true;
            }

            return updated;
        }
    }
}
