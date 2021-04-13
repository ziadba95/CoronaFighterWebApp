using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPRCoronaFighter.Models
{
    public class GroupAndPost
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Group> Groups { get; set; }

    }
}