using core1.Entities;
using core1.Specifications;
using PetarSkinet.core1.Specification;

namespace core1.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecifcation<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecParam productParams)  : base(x => 
            //(string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.Brandid.HasValue || x.ProductBrandId == productParams.Brandid) &&
            (!productParams.Typeid.HasValue || x.ProductTypeId == productParams.Typeid))
        {
            
        }
        
    }
}
