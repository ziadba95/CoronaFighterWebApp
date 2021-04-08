using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPRCoronaFighter.Models
{
    public class CommentAndPost
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public CommentAndPost()
        {
            BPRCoronaFighterContext db = new BPRCoronaFighterContext();
            this.Posts = db.Posts.ToList();
            this.Comments = db.Comments.ToList();
        }

    }
}