using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class ProductLabel:Entity
    {
        public ProductLabel()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string OtherValue { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
