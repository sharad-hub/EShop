using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapping
{
   public class MenuMap : EntityTypeConfiguration<Menu>
    {
       public MenuMap()
       {
           this.HasKey(m => m.Id);
       }
    }
}
