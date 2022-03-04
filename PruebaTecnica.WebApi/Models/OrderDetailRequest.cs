using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Models
{
    public class OrderDetailRequest
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
    }
}
