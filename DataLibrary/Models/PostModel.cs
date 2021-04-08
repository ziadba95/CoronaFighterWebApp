using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class PostModel
    {
        public int? PostId { get; set; }
        public string PostAuthor { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public string UserID { get; set; }
        public int numOfLike { get; set; }
    }
}
