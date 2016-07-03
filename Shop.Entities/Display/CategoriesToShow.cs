using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.Display
{
   public class CategoriesToShow:Entity
    {
       public CategoriesToShow()
       {
           this.Products = new List<Product>();
       }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
