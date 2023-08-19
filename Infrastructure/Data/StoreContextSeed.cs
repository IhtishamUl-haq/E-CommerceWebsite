using Core.Entites;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {

            try
            {
                if(!context.ProductBrands.Any())
                {

                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                      var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {

                    var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var type = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    foreach (var item in type)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {

                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var product = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in product)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex) {
                //var log = loggerFactory.CreateLogger<Program>();
                //log.LogError(e, "Error ocurred in Migration");
            }
        }
    }
}
