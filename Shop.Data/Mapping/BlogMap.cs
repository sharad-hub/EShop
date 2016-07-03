using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapping
{
  public class BlogMap:EntityTypeConfiguration<Blog>
    {
      public BlogMap()
      {
         // this.HasOptional(t => t.BlogComment)
         //.WithMany(t => t.Comments)
         //.HasForeignKey(d => d.BlogCommentID);

          this.HasOptional(s => s.BlogComment) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Blog);
          this.HasMany(s => s.Likes);
              // Mark Address property optional in Student entity               
                //.WithRequired(ad => ad.LikedBy);
      }
    }
}
