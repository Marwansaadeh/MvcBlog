using Microsoft.AspNetCore.Mvc.Rendering;
using SportBlogPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.ViewModels
{
    public class PostsAndCategories
    {
        public IEnumerable<Category> Categories{get;set;}
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<SelectListItem> CategoriesList { get; set; }
        
        public Post Post { get; set; }
        public Category Category { get; set; }

    }
}
