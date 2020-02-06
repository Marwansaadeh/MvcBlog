using SportBlogPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.IRepository
{
   public interface IPostRepository:  IRepository<Post>
    {
        IEnumerable<Post> GetPostByLastDates();
        IEnumerable<Post> SearchForPost(Category category, Post Post);
        IEnumerable<Post> SearchForPost(int categoryid);

    }
}
