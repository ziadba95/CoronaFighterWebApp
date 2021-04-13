using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BPRCoronaFighter.Models
{
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        public int CommentId { get; set; }
        public string UserID { get; set; }
        public string PostID { get; set; }
        [Required]
        [Display(Name = "Comment")]
        public string CommentText { get; set; }
        public string CommentAuthor { get; set; }
        public string CommentDate { get; set; }
    }
}