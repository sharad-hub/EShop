using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities.Procedures
{
   public  partial class ProductUIDetail
    {
       public int ProductID { get; set; }
       public string ProductLabel { get; set; }
       public Nullable<int> PercentageDiscount { get; set; }
       public string DiscountText { get; set; }
       public string ProductTag { get; set; }
       public Nullable<Decimal> UnitPrice { get; set; }
       public string ProductName { get; set; }   
    }
}
