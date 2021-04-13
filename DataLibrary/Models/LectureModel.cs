using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class LectureModel
    {
        public int? LectureId { get; set; }
        public string LectureTitle { get; set; }
        public string LectureDescription { get; set; }
        public string LectureLink { get; set; }
        public DateTime LectureDate { get; set; }
        public DateTime LectureTime { get; set; }
        public int numOfLike { get; set; }
        public string UserID { get; set; }
        public string LectureAuthor { get; set; }
    }
}
