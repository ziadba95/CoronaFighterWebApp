using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Models
{
    public class OfferHelp
    {
        [HiddenInput(DisplayValue = false)]
        public int HelpId { get; set; }

        [Required]
        [Display(Name = "Help Title")]
        public string HelpTitle { get; set; }

        [Required]
        [Display(Name = "Help Description")]
        [DataType(DataType.MultilineText)]
        [UIHint("DisplayPostalAddr")]
        public string HelpDescription { get; set; }
        
        [Required]
        [Display(Name = "Help Date")]
        [DataType(DataType.Date)]
        public DateTime HelpDate { get; set; }

        [Required]
        [Display(Name = "Help Time")]
        [DataType(DataType.Time)]
        public DateTime HelpTime { get; set; }

        [Required]
        [Display(Name = "Free hours")]
        public string FreeHour { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
    }
}