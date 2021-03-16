
using core1.Interfaces;
using core1.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using core1.Specification;
using PetarSkinet.Dtos;
using System.Linq;
using AutoMapper;

namespace PetarSkinet.Controllers
{
    
    public class ProductsController : BaseApiController

    {
        private readonly IGenericRepository<Product> product;
        private readonly IGenericRepository<ProductBrand> brand;
        private readonly IGenericRepository<ProductType> type;
        private readonly IMapper map;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandRepo,IGenericRepository<ProductType> typeRepo, IMapper mapper)
        {
            product = productRepo;
            brand = brandRepo;
            type = typeRepo;
            map = mapper;
        }
        [HttpGet]
        public async Task< ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await product.ListAsync(spec);
            return Ok(map.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var products = await product.GetEntityWithSpec(spec);
            return map.Map<Product, ProductToReturnDto>(products);
            
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await brand.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await type.ListAllAsync();
            return Ok(types);
        }
    }
}
