
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
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandRepo,IGenericRepository<ProductType> typeRepo)
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
        }
        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _brandRepo.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await _typeRepo.GetAllAsync();
            return Ok(types);
        }
    }
}
