using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManualIdentity.Models
{
    public class IdentityContext: DbContext
    {
        public IdentityContext(): base("main") { }

        public DbSet<User> Users { get; set; }
    }
}