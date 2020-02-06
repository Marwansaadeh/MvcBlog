using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportBlogPost.IRepository;
using SportBlogPost.Models;
using SportBlogPost.ViewModels;
using static System.Net.WebRequestMethods;

namespace SportBlogPost.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository _postRepository;
        private ICategoryRepository _categoryRepository;

        public HomeController(IPostRepository PostRepository, ICategoryRepository CategoryRepository)
        {
            _postRepository = PostRepository;
            _categoryRepository = CategoryRepository;
        }
        public IActionResult Index()
        {
           var model= new PostsAndCategories();
            model.Posts = _postRepository.GetPostByLastDates();
            model.Categories = _categoryRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ViewResult AddPost()
        {
            var list= _categoryRepository.GetAll().Select(c => new SelectListItem
            {

                Text = c.CategoryName,

                Value = c.CategoryID.ToString()
            }
            ).ToList();
            list.Insert(0, new SelectListItem { Text = "Please Select...", Value = string.Empty });


            AddPost model = new AddPost();
            model.CategoriesList = list;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(Post post)
        {
           
            if (!ModelState.IsValid)
            {
                AddPost model = new AddPost();

                model.CategoriesList = _categoryRepository.GetAll().Select(c => new SelectListItem
                {
                    Text = c.CategoryName,

                    Value = c.CategoryID.ToString()
                }
                );
                return View(model);  
            }
            else
            {
                post.PostDate = DateTime.Now;
                _postRepository.Add(post);
                return RedirectToAction("Index");
            }

        }
       

        public IActionResult Search()
        {
          
            return View();

        }
        [HttpPost]
        public IActionResult Search(Category category, Post post)
        {
            var model = new PostsAndCategories();
            model.Posts = _postRepository.SearchForPost(category, post);
            model.CategoriesList = _categoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,

                Value = c.CategoryID.ToString()

            });

            return View(model);
        }
        public IActionResult PostDetails(int id)
        {
            var model = new PostDetails();
            model.Post = _postRepository.Get(id);
            model.Category = _categoryRepository.Get(model.Post.CategoryID);
            return View(model);
        }
        public IActionResult CategoryPosts(int id)
        {
            var model = new PostsAndCategories();
            model.Posts = _postRepository.SearchForPost(id);
            model.CategoriesList = _categoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,

                Value = c.CategoryID.ToString()

            });

            return View(model);

           
        }

        public IActionResult GetPostCategoriesSubjects()
        {
            var model = new PostsAndCategories();
            model.Categories = _categoryRepository.GetAll();
            model.Posts = _categoryRepository.CategoriesPosts().ToList();
            return View(model);
        }
    }
}