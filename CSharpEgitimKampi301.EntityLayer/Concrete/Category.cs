using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {

        /* Field, Property ve Variable Farkı:
         * Field    : Sınıf içerisinde tanımlanan ve genellikle private erişim belirleyicisi ile kullanılan değişkenlerdir. 
         *            Field'lar genellikle sınıfın iç durumunu tutmak için kullanılır.
         * Property : Sınıfın dışarıya açtığı ve genellikle public erişim belirleyicisi ile kullanılan özelliklerdir.
         *            Property'ler, field'ların değerlerine kontrollü erişim sağlamak için kullanılır. Property'ler get ve set erişimcileri ile tanımlanır.
         * Variable : Genel bir terim olup, herhangi bir veri türünü temsil eden ve değer tutabilen isimlendirilmiş bellek alanlarını ifade eder.
         *            Field'lar ve Property'ler de değişken türleridir.
        */

        // Category sınıfının özellikleri (properties) sütun olarak düşünülebilir.
        public int CategoryId { get; set; } // Birincil anahtar (Primary Key) olarak kullanılabilmesi için SınıfadıId şeklinde yazılmalıdır.
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public virtual List<Product> Products { get; set; } // Navigation Property
    }
}
