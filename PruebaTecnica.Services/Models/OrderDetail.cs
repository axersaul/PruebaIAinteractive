using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services.Models
{
    public class OrderDetail
    {
        private Product _product;
        private int _quantity;

        public Product Product 
        { 
            get =>_product; 
            set => _product = value; 
        }
        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
        public OrderDetail()
        {
            _product = new(string.Empty, string.Empty);
        }

    }
}
