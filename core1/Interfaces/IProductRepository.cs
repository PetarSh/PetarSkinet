using core1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core1.Interfaces
{
   public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetTypesAsync();


    }
}
