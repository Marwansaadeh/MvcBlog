using SportBlogPost.IRepository;
using SportBlogPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public SportBlogContext Db
        {
            get { return DatabaseContext as SportBlogContext; }
        }

        public PostRepository(SportBlogContext context) : base(context) {  }

        public IEnumerable<Post>GetPostByLastDates()
        {
            var PostList = Db.Posts.OrderByDescending(x => x.PostDate).ToList();

            return PostList;
        }

        public IEnumerable<Post> SearchForPost(Category categoryid, Post post)
        {
            
            if (post.Subject == null && categoryid.CategoryID != 0)
            {
                var PostByCategory = Db.Posts.Where(p => p.CategoryID == categoryid.CategoryID).OrderByDescending(x=>x.PostDate).ToList();

                return PostByCategory;
            }
            else if (categoryid.CategoryID == 0 && post.Subject != null)
            {
                var PostsByTitle = Db.Posts.Where(x => x.Subject.Contains(post.Subject)).OrderByDescending(x => x.PostDate).ToList();

                return PostsByTitle;
            }
            else if (categoryid.CategoryID == 0 && post.Subject == null)
            {
                var PostsByTitle = Db.Posts.OrderByDescending(x => x.PostDate).ToList();

                return PostsByTitle;
            }
            else
            {
                var PostByTitelAndCategory = Db.Posts.Where(p => p.CategoryID == categoryid.CategoryID && p.Subject.Contains(post.Subject)).OrderByDescending(x => x.PostDate).ToList();
                return PostByTitelAndCategory;
            }

        }

        public IEnumerable<Post> SearchForPost(int categoryid)
        {
                var PostByCategory = Db.Posts.Where(p => p.CategoryID == categoryid).OrderByDescending(x => x.PostDate).ToList();

               return PostByCategory;

        }


    }
}
