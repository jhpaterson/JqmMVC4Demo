using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JqmMVC4Demo.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("name = BlogDbConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Post> Posts { get; set; }
    }
}