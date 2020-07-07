using BlueModasStore.Domain.Interfaces.Services;
using BlueModasStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return await productService.GetProductById(id);
        }
    }
}
