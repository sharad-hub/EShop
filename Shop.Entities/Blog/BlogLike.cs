using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Entities
{
   public class BlogLike:Entity
    {
        public int ID { get; set; }
        //public string CommentText { get; set; }
        public DateTime LikedOn { get; set; }
        public User LikedBy { get; set; }
        public int LikedByID { get; set; }
        //public virtual Blog Blog { get; set; }      
    }
}
