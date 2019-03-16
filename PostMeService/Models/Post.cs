using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PostMeService.Models
{
    public class Post
    {
        [Key]
        public int postId { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public string headline { get; set; }
        public string description { get; set; }
        public DateTime time { get; set; }
        public int upvotes { get; set; }

        public virtual User user { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
    }
}
