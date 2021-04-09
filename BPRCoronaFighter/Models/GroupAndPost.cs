using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPRCoronaFighter.Models
{
    public class GroupAndPost
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Group> Group { get; set; }
        public GroupAndPost()
        {
            BPRCoronaFighterContext db = new BPRCoronaFighterContext();
            this.Posts = db.Posts.ToList();
            this.Group = db.Group.ToList();
        }

    }
}