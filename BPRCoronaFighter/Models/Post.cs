﻿using System;
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
        public int? PostId { get; set; }
        [Required]
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }
        [Required]
        [Display(Name = "Write Here:")]
        public string PostContent { get; set; }
        public DateTime? PostDate { get; set; }






    }
}