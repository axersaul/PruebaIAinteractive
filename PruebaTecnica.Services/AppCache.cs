using PruebaTecnica.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services
{
    public class AppCache
    {

        private static List<Product> _products;
        private static List<Order> _orders;
        private static List<Stock> _stock;

        public static List<Product> ProductsInstance
        {
            get
            {
                if(_products is null)
                {
                    _products = new List<Product>();
                }
                return _products;
            }
        }
        public static List<Order> OrderInstance
        {
            get
            {
                if (_orders is null)
                {
                    _orders = new List<Order>();
                }
                return _orders;
            }
        }
        public static List<Stock> StockInstance
        {
            get
            {
                if (_stock is null)
                {
                    _stock = new List<Stock>();
                }
                return _stock;
            }
        }
    }
}
