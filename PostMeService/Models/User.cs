using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostMeService.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public virtual ICollection<Post> posts { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
    }
}
