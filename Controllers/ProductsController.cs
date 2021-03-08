using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Structura.Data;
using Structura.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetarSkinet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext storeContext)
        {
            context = storeContext;
        }
        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var products =await context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Product>> GetProduct(int id)
        {
            var product =await context.Products.FindAsync(id);
            return Ok(product);
        }
    }
}
