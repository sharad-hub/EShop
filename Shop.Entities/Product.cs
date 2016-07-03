using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;
using Shop.Entities.Display;

namespace Shop.Entities
{
    public partial class Product : Entity
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.ProductTags = new List<ProductTag>();
            this.DiscountsAvailable = new List<Discount>();
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> ProductLabelId { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
        public string Image { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<Discount> DiscountsAvailable { get; set; }   
        public ProductLabel ProductLabel { get; set; }

        public Nullable<int> CategoriesToShowId { get; set; }
        public CategoriesToShow CategoriesToShow { get; set; }
    }
}
