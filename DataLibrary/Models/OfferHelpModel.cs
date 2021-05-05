using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OfferHelpModel
    {
        public int HelpId { get; set; }
        public string HelpTitle { get; set; }
        public string HelpDescription { get; set; }
        public DateTime HelpDate { get; set; }
        public DateTime HelpTime { get; set; }
        public string FreeHour { get; set; }
        public string Contact { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
    }
}
