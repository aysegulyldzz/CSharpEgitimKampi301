using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }  // Foreign Key
        public virtual Product Product { get; set; } // Navigation Property
        public int CustomerId { get; set; } // Foreign Key
        public virtual Customer Customer { get; set; } // Navigation Property
        
        //public DateTime OrderDate { get; set; }
        public short OrderQuantity { get; set; }
        public decimal OrderUnitPrice { get; set; }
        public decimal OrderTotalPrice { get; set; }
    }
}
