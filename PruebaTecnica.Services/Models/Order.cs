using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services.Models
{
    public class Order
    {
        private int _id;
        private List<OrderDetail> _details;
        private decimal _total;

        public List<OrderDetail> Details 
        { 
            get => _details; 
            set => _details =value; 
        }
        public decimal Total
        {
            get => _total;
            set => _total = value;
        }
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public StatusOrder Status { get; set; }

        public Order()
        {
            _details = new();
        }

    }
    public enum StatusOrder
    {
        Pending,
        InProccess,
        Completed,
        Delivered,
        Canceled
    }
}
