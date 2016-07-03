using Shop.Entities;  
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapping
{
     
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            Property(ur => ur.Name).IsRequired().HasMaxLength(50);
        }
    }
}
