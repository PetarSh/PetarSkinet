
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
        private readonly IGenericRepository<Product> product;
        private readonly IGenericRepository<ProductBrand> brand;
        private readonly IGenericRepository<ProductType> type;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandRepo,IGenericRepository<ProductType> typeRepo)
        {
            product = productRepo;
            brand = brandRepo;
            type = typeRepo;
        }
        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var products = await product.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id)
        {
            var products = await product.GetByIdAsync(id);
            return Ok(products);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await brand.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await type.GetAllAsync();
            return Ok(types);
        }
    }
}
