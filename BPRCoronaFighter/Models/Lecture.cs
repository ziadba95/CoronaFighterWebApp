using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Models
{
    public class Lecture
    {
        [HiddenInput(DisplayValue = false)]
        public int? LectureId { get; set; }
        [Required]
        [Display(Name ="Lecture Title")]
        public string LectureTitle { get; set; }
        [Required]
        [Display(Name = "Lecture Description")]
        public string LectureDescription { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Lecture Date")]
        public DateTime LectureDate { get; set; }



    }
}