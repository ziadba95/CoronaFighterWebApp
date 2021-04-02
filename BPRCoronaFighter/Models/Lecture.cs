using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DataType(DataType.MultilineText)]
        [UIHint("DisplayPostalAddr")]
        public string LectureDescription { get; set; }
        [Required]
        [Display(Name = "Lecture Link")]
        public string LectureLink { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:U}")]
        [Display(Name = "Lecture Date")]
        [DataType(DataType.Date)]
        public DateTime LectureDate { get; set; }



    }
}