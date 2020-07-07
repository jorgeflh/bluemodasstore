using BlueModasStore.Domain.Interfaces.Repositories;
using BlueModasStore.Domain.Interfaces.Services;
using BlueModasStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModasStore.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<bool> AddProduct(Product product)
        {
            return productRepository.AddProduct(product);
        }

        public Task<Product> GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        public Task<List<Product>> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public Task<bool> RemoveProduct(int id)
        {
            return productRepository.RemoveProduct(id);
        }

        public Task<bool> UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
    }
}
