using Shop.Entities.Display;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapping
{
   public class CategoriesToDisplayMap:EntityTypeConfiguration<CategoriesToShow>
    {
       public CategoriesToDisplayMap()
       {
           this.HasKey(x => x.ID);
           //this.HasRequired(t => t.Products)
           //   .WithMany(t => t.OrderDetails)
           //   .HasForeignKey(d => d.OrderID);
           //this.HasMany(x => x.Products);
       }
    }
}
