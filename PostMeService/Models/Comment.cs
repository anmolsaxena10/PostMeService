using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostMeService.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public DateTime time { get; set; }
        public string description { get; set; }
        public int upvotes { get; set; }

        [ForeignKey("user")]
        public int userId { get; set; }

        [ForeignKey("post")]
        public int postId { get; set; }

        [ForeignKey("comment")]
        public int? replyOfCommentId { get; set; }

        public virtual User user { get; set; }
        public virtual Post post { get; set; }
        public virtual Comment replyOfComment { get; set; }
        public virtual ICollection<Comment> replyComments { get; set; }
    }
}
