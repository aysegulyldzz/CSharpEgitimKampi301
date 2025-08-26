using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public virtual Category Category { get; set; } // Navigation Property
        public decimal ProductPrice { get; set; }
        public short ProductStock { get; set; }
        public string ProductDescription { get; set; }

        public virtual List<Order> Orders { get; set; } // Navigation Property
    }
}
