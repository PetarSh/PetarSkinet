using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core1.Entities;
using core1.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Structura.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;
        public ProductRepository(StoreContext storeContext)
        {
            context = storeContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
                .Include(P => P.ProductBrand)
                .Include(P => P.ProductType)

                .FirstOrDefaultAsync(P=>P.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await context.Products
                .Include(P=>P.ProductBrand)
                .Include(P => P.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetTypesAsync()
        {
            return await context.ProductTypes.ToListAsync();
        }
    }
}
