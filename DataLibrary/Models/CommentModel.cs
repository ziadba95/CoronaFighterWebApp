using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CommentModel
    {
        public int? CommentId { get; set; }
        public string UserID { get; set; }
        public string PostID { get; set; }
        public string CommentText { get; set; }
        public string CommentAuthor { get; set; }
        public string CommentDate { get; set; }
    }
}
