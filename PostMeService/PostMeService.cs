using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostMeService
{
    class PostMeService : IPostMeService
    {
        public Types.User getUser(int userId)
        {
            using(var ctx = new Models.Model())
            {
                Models.User u = ctx.users.FirstOrDefault(x => x.userId == userId);
                Types.User u1 = new Types.User();
                u1.userId = u.userId;
                u1.username = u.username;
                u1.firstName = u.firstName;
                u1.lastName = u.lastName;
                u1.password = u.password;

                return u1;
            }
        }

        public int addUser(Types.User u)
        {
            using (var ctx = new Models.Model())
            {
                Models.User u1 = new Models.User();
                u1.username = u.username;
                u1.firstName = u.firstName;
                u1.lastName = u.lastName;
                u1.password = u.password;
                ctx.users.Add(u1);
                ctx.SaveChanges();
                return u1.userId;
            }
        }

        public void removeUser(int userId)
        {
            using (var ctx = new Models.Model())
            {
                ctx.users.Remove(ctx.users.FirstOrDefault(x => x.userId == userId));
                ctx.SaveChanges();
            }
        }

        public Types.User updateUser(Types.User u)
        {
            using (var ctx = new Models.Model())
            {
                Models.User u1 = ctx.users.FirstOrDefault(x => x.userId == u.userId);
                u1.username = u.username;
                u1.firstName = u.firstName;
                u1.lastName = u.lastName;
                u1.password = u.password;
                ctx.SaveChanges();
                return u;
            }
        }
    }
}
