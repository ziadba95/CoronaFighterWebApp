using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BPRCoronaFighter.Models
{
    public class BPRCoronaFighterContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BPRCoronaFighterContext() : base("name=BPRCoronaFighterContext")
        {
        }

        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.Group> Groups { get; set; }
        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<BPRCoronaFighter.Models.Post> Posts { get; set; }
    }
}
