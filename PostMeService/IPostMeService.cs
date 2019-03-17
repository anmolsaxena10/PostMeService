using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PostMeService
{
    [ServiceContract]
    public interface IPostMeService
    {
        [OperationContract]
        Types.User getUser(int userId);

        [OperationContract]
        int addUser(Types.User user);

        [OperationContract]
        void removeUser(int userId);

        [OperationContract]
        Types.User updateUser(Types.User user);

        [OperationContract]
        Types.Post getPost(int postId);

        [OperationContract]
        int addPost(Types.Post post);

        [OperationContract]
        void removePost(int postId);

        [OperationContract]
        Types.Post updatePost(Types.Post post);

        [OperationContract]
        List<Types.Post> filterPosts(
            int? userId = null,
            string headline = null,
            DateTime? date = null);
    }
}
