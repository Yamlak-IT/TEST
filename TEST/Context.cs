using TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TEST
{
    public class Context:DbContext
    {
        public Context() : base() { }
        public DbSet<Product> Product { get; set; }
    }
}