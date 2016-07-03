using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
  public partial class Discount:Entity
    {
      public Discount()
      {
          this.Products = new List<Product>();
      }
        public int Id { get; set; }
        public int MinQuantity { get; set; }
        public int PercentageDiscount { get; set; }
        public bool IsAvailable { get; set; }
        public string Text { get; set; }
        public string Summary { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
