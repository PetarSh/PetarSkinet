﻿
using core1.Interfaces;
using core1.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using core1.Specification;
using PetarSkinet.Dtos;
using System.Linq;

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
        public async Task< ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await product.ListAsync(spec);
            return products.Select(product => new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var products = await product.GetEntityWithSpec(spec);
            return new ProductToReturnDto
            {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                PictureUrl = products.PictureUrl,
                ProductType = products.ProductType.Name,
                ProductBrand = products.ProductBrand.Name
            };
            
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
