using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Models
{
    public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int PostId { get; set; }
        [Required]
        [Display(Name = "Post Author")]
        public string PostAuthor { get; set; }
        [Required]
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }
        [Required]
        [Display(Name = "Write Here:")]
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public string UserID { get; set; }
        public int numOfLike { get; set; }




    }
}