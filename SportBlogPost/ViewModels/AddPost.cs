using Microsoft.AspNetCore.Mvc.Rendering;
using SportBlogPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.ViewModels
{
    public class AddPost
    {

        public Category Category { get; set; }
        public Post Post { get; set; }

        public IEnumerable<SelectListItem> CategoriesList { get; set; }
    
    }
}
