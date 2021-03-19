using core1.Entities;
using core1.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core1.Specification
{
    public class ProductsWithTypesAndBrandsSpecification :BaseSpecifcation<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandid, int? typeid)
            : base(x =>
             (!brandid.HasValue || x.ProductBrandId == brandid) &&

             (!typeid.HasValue || x.ProductTypeId == typeid)

            )
 
            
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
