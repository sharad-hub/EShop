using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace Shop.Entities
{
    public partial class Category : Entity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
       //[JsonIgnore]
        public byte[] Picture { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
