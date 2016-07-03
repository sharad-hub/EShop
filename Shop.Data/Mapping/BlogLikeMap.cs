using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapping
{
    public class BlogLikeMap : EntityTypeConfiguration<BlogLike>
    {
        public BlogLikeMap()
        {
            this.HasKey(x => x.ID);
        }
    }
}
