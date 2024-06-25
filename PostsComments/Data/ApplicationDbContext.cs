using Microsoft.EntityFrameworkCore;
using PostsComments.Data.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace PostsComments.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(s => s.Post) // Use HasOne instead of HasRequired
                .WithMany(g => g.Comments)
                .HasForeignKey(s => s.PostId)
                .IsRequired(); // Use IsRequired method to specify the foreign key is required
        }
    }
}
