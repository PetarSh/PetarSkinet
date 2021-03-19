using core1.Entities;
using core1.Specifications;
using PetarSkinet.core1.Specification;

namespace core1.Specification
{
    public class ProductsWithTypesAndBrandsSpecification :BaseSpecifcation<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParam specParam)
            : base(x =>
             (! specParam.Brandid.HasValue || x.ProductBrandId == specParam.Brandid) &&

             (!specParam.Typeid.HasValue || x.ProductTypeId == specParam.Typeid)

            )
 
            
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(specParam.PageSize * (specParam.pageIndex - 1),specParam.PageSize);

            if (!string.IsNullOrEmpty(specParam.Sort))
            {
                switch (specParam.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
            public ProductsWithTypesAndBrandsSpecification(int id):base(x =>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
        }
    }
