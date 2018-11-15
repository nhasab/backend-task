using netways_task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace netways_task.DAL
{
    public class NetwaysContext : DbContext
    {
        public NetwaysContext() : base("NetwaysTaskDb") { }
        public DbSet<UserProfile> UserProfile {get; set;}
        public DbSet<Country> Countries {get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}