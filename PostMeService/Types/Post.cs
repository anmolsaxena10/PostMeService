using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PostMeService.Types
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int postId { get; set; }
        [DataMember]
        public string headline { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public int upvotes { get; set; }
        [DataMember]
        public Types.User user { get; set; }
    }
}
