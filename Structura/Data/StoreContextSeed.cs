﻿using core1.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace Structura.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
               if(!context.ProductBrands.Any())
                {
                    var brandsdata = File.ReadAllText("../Structura/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesdata = File.ReadAllText("../Structura/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var pdata = File.ReadAllText("../Structura/SeedData/products.json");
                    var product = JsonSerializer.Deserialize<List<Product>>(pdata);

                    foreach (var p in product)
                    {
                        context.Products.Add(p);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "Greska pri seed data");
            }
        }
    }
}
