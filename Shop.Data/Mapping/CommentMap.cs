using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            this.HasKey(x => x.ID);
       

                //       this.HasMany<Comment>(s => s.Comments)
                //.WithMany(c => c.Comments)
                //.Map(cs =>
                //        {
                //            cs.MapLeftKey("CommentParentId");
                //            cs.MapRightKey("CommentId");
                //            cs.ToTable("CommentsComment");
                //        });
        }
    }

    public class BlogCommentMap : EntityTypeConfiguration<BlogComment>
    {
        public BlogCommentMap()
        {
            this.HasMany(c => c.Comments).WithOptional(x => x.BlogComments);
        }
    }
}
