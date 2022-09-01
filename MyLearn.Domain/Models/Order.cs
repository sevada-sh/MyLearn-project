using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public Course Course { get; set; }

    }
}
