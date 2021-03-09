
using core1.Entities;
using core1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetarSkinet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository repo)
        {
            productRepository = repo;
        }
        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var products = await productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await productRepository.GetBrandsAsync();
            return Ok(brands);
        }
    }
}
