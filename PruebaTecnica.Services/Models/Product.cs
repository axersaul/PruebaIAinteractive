using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services.Models
{
    public class Product
    {
        private string _sku;
        private string _name;

        public string Sku
        {
            get => _sku;
            set => _sku = value;
        }
        public string Name
        {
            get => _name; set => _name = value;
        }
      

        public Product(string sku, string name)
        {
            _sku = sku;
            _name = name;
        }
    }
}
