
using core1.Interfaces;
using core1.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetarSkinet.Dtos;
using AutoMapper;
using PetarSkinet.Errors;
using Microsoft.AspNetCore.Http;
using PetarSkinet.core1.Specification;
using core1.Specification;
using PetarSkinet.Helpers;
using core1.Specifications;

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
        public async Task< ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParam specParam)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(specParam);
            var countSpec = new ProductsWithFiltersForCountSpecification(specParam);
            var totalItems = await product.CountAsync(countSpec);
            var products = await product.ListAsync(spec);
            var data = map.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);


            return Ok(new Pagination<ProductToReturnDto>(specParam.pageIndex,specParam.PageSize,totalItems,data));
        }
       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task< ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var produkt = await product.GetEntityWithSpec(spec);
            if (produkt == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return map.Map<Product, ProductToReturnDto>(produkt);
            
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
