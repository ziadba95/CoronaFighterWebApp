using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class GroupModel
    {
        public int? GroupId { get; set; }
        public string GroupName { get; set; }
        public string UserID { get; set; }
        public string GroupTime { get; set; }
        public string GroupCreater { get; set; }
    }
}
