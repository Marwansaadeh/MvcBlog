using SportBlogPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Post> CategoriesPosts();
    }
}
