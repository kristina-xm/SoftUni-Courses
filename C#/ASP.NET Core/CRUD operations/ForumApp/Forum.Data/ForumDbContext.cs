using ASP_ForumApp.Data.Configuration;
using ASP_ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_ForumApp.Data
{
    public class ForumDbContext : DbContext
    {
        //!!!
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options) 
        { 


        }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
