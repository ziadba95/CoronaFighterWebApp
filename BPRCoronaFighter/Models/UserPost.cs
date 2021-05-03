using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace BPRCoronaFighter.Models
{
    // Test
    public class UserPost
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public string PostAuthor { get; set; }
    }

}