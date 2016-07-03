using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
   public class Blog:Entity
    {
       public Blog()
       {          
           this.Likes = new List<BlogLike>();
       }
        public int ID { get; set; }
        public string Subject { get; set; }
        public DateTime DateCreated { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedByID { get; set; }
        public string BlogContent { get; set; }
        public string BlogImage { get; set; }

        public int ViewCount { get; set; }

        public Nullable<int> BlogCommentID { get; set; }
        public virtual BlogComment BlogComment { get; set; }
        public virtual ICollection<BlogLike> Likes { get; set; }
    }
}
