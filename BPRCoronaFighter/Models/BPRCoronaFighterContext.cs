using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BPRCoronaFighter.Models
{
    public class BPRCoronaFighterContext : DbContext
    {
        public BPRCoronaFighterContext() : base("name=BPRCoronaFighterContext")
        {
        }
        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.Group> Groups { get; set; }
        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.Post> Posts { get; set; }
        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.UserGroup> UserGroups { get; set; }
    }
}
