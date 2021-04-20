using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace DataLibrary.Models
{
    public class DoctorModel
    {
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        //public HttpPostedFileBase Document { get; set; }
        public string  ApplicationDate { get; set; }
        public string AppStatus { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
