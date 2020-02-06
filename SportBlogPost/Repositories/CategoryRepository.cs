using SportBlogPost.IRepository;
using SportBlogPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public SportBlogContext Db
        {
            get { return DatabaseContext as SportBlogContext; }
        }

        public CategoryRepository(SportBlogContext context) : base(context) { }

        public IEnumerable<Post> CategoriesPosts()
        {
            return Db.Posts.ToList();
        }
    }
}
