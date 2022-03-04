using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services.Models
{
    public class Stock
    {
        private Product _product;
        private int _stockQuantity = 10;

        public Product Product 
        { 
            get => _product; 
            set => _product =value; 
        }
        public int StockQuantity
        {
            get => _stockQuantity;
            set => _stockQuantity = value;
        }

    }
}
