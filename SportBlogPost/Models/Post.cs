using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.Models
{
    public class Post
    {
         
        [Key]
        public int PostID { get; set; }
        [Required(ErrorMessage = "Please select the subject")]

        public int CategoryID { get; set; }


        [Required(ErrorMessage = "Please Writ the subject of the post")]
        [MaxLength(50,ErrorMessage ="Max character of the subject is 50 character")]
        [MinLength(3, ErrorMessage = "Subject must contain 3 character")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please Writ the text of the post")]
        [MaxLength(2000, ErrorMessage = "Max character of the post text is 50 character")]
        [MinLength(15, ErrorMessage = "Post text must contain 15 character")]
        [Display(Name = "Text", AutoGenerateFilter = false)]
        public string Body { get; set; }
        public DateTime PostDate { get; set; }

        public Category Category { get; set; }

    }
}
