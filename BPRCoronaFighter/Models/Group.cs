using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Models
{
    public class Group
    {
        [HiddenInput(DisplayValue = false)]
        public int GroupId { get; set; }
        [Required]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        public string UserID { get; set; }
        public string GroupTime { get; set; }
        public string GroupCreater { get; set; }
    }
}