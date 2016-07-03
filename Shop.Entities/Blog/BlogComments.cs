using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Entities
{
    public class BlogComment : Entity
    {
        public BlogComment()
        {
            this.Comments = new List<Comment>();
        }
        public int ID { get; set; }
        public virtual Blog Blog { get; set; }
        public int BlogID { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
    public class Comment : Entity
    {
        public int ID { get; set; }
        public Nullable<int> BlogCommentID { get; set; }
        public BlogComment BlogComments { get; set; }
        public string CommentText { get; set; }
        public virtual User CommentedBy { get; set; }
        public DateTime CommentedOn { get; set; }
        public int CommentedByID { get; set; }
      //  public virtual ICollection<Comment> Comments { get; set; }
    }
}
