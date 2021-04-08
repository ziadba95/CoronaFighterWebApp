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
        [Display(Name = "Lecture Date")]
        [DataType(DataType.Date)]
        public DateTime LectureDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime LectureTime { get; set; }
        public int numOfLike { get; set; }
        public string UserID { get; set; }
        public string LectureAuthor { get; set; }
    }
}