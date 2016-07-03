using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public partial class ProductTag : Entity
    {
        public ProductTag()
        {
           this.Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Tag { get; set; }
        public bool IsValid { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
