using PruebaTecnica.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services
{
    public static class ProductService
    {
        public static Product GetBySku(string sku)
        {
            Product product = AppCache.ProductsInstance.FirstOrDefault(x => x.Sku == sku);
            return product ?? new Product(string.Empty, string.Empty);
        }
        public static int Add(Product product)
        {
            try
            {
                var result = AppCache.ProductsInstance.FirstOrDefault(x => x.Sku == product.Sku);
                if (result is not null)
                    return 1;

                AppCache.ProductsInstance.Add(product);
                AppCache.StockInstance.Add(new Stock() { Product = product, StockQuantity = 10 });
                return 0;
            }
            catch (Exception)
            {

                return 1;
            } 
        }
        public static int Modify(string sku, Product product)
        {
            try
            {
                Product result = AppCache.ProductsInstance.FirstOrDefault(x => x.Sku == sku);
                if (result is null)
                    return 1;
                result.Name = product.Name;
                return 0;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public static int Delete(string sku)
        {
            try
            {
                AppCache.ProductsInstance.RemoveAll(x => x.Sku == sku);
                return 0;
            }
            catch (Exception)
            {

                return 1;
            }
        }
    }
}
