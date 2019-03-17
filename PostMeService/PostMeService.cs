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

        /********************************************************************************/

        public Types.Post getPost(int postId)
        {
            using (var ctx = new Models.Model())
            {
                Models.Post p = ctx.posts.FirstOrDefault(x => x.postId == postId);
                Types.Post p1 = new Types.Post();
                p1.postId = p.postId;
                p1.headline = p.headline;
                p1.time = p.time;
                p1.description = p.description;
                p1.upvotes = p.upvotes;
                p1.user = new Types.User();
                p1.user.userId = p.user.userId;
                p1.user.username = p.user.username;
                p1.user.firstName = p.user.firstName;
                p1.user.lastName = p.user.lastName;
                p1.user.password = p.user.password;
                return p1;
            }
        }

        public int addPost(Types.Post p)
        {
            using (var ctx = new Models.Model())
            {
                Models.Post p1 = new Models.Post();
                p1.headline = p.headline;
                p1.time = p.time;
                p1.description = p.description;
                p1.upvotes = p.upvotes;
                Models.User u = ctx.users.FirstOrDefault(x => x.userId == p.user.userId);
                p1.user = u;
                ctx.posts.Add(p1);
                ctx.SaveChanges();
                return p1.postId;
            }
        }

        public void removePost(int postId)
        {
            using (var ctx = new Models.Model())
            {
                ctx.posts.Remove(ctx.posts.FirstOrDefault(x => x.postId == postId));
                ctx.SaveChanges();
            }
        }

        public Types.Post updatePost(Types.Post p)
        {
            using (var ctx = new Models.Model())
            {
                Models.Post p1 = ctx.posts.FirstOrDefault(x => x.postId == p.postId);
                p1.headline = p.headline;
                p1.time = p.time;
                p1.description = p.description;
                p1.upvotes = p.upvotes;
                ctx.SaveChanges();
                return p;
            }
        }

        public List<Types.Post> filterPosts(
            int? userId = null,
            string headline = null,
            DateTime? date = null)
        {
            using(var ctx = new Models.Model())
            {
                var posts = ctx.posts.AsParallel();
                if (userId != null)
                {
                    posts = posts.Where(x => x.user.userId == userId);
                }
                if(headline != null)
                {
                    posts = posts.Where(x => x.headline.Contains(headline));
                }
                if(date != null)
                {
                    posts = posts.Where(x => (DateTime.Compare((DateTime)date, x.time) <= 0));
                }
                List<Types.Post> result = new List<Types.Post>();
                foreach (var p in posts.ToList())
                {
                    var p1 = new Types.Post();
                    p1.postId = p.postId;
                    p1.headline = p.headline;
                    p1.time = p.time;
                    p1.description = p.description;
                    p1.upvotes = p.upvotes;
                    p1.user = new Types.User();
                    p1.user.userId = p.user.userId;
                    p1.user.username = p.user.username;
                    p1.user.firstName = p.user.firstName;
                    p1.user.lastName = p.user.lastName;
                    p1.user.password = p.user.password;
                    result.Add(p1);
                }
                return result;
            }

        }
    }
}
