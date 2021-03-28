using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPRCoronaFighter.Models
{
    public class Application
    {
        [HiddenInput(DisplayValue=false)]
        public int? ApplicationId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Required]
        [Display(Name = "Upload Your Licence")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Document { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime? ApplicationDate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool? ApplicationStatus { get; set; }


    }
}