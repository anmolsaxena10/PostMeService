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
    }
}
