using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PostMeService.Types
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public int commentId { get; set; }
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public int upvotes { get; set; }
        [DataMember]
        public Types.User user { get; set; }
        [DataMember]
        public Types.Post post { get; set; }
        [DataMember]
        public Types.Comment replyOfComment { get; set; }
    }
}
