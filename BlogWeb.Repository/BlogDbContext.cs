using BlogWeb.Repository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository
{
    public class BlogDbContext : IdentityDbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<BlogPostCategory> BlogPostCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important for Identity   


            // BlogPost
            modelBuilder.Entity<BlogPost>()
                .HasOne(b => b.Author)
                .WithMany() // IdentityUser doesn't have a collection of BlogPosts by default
                .HasForeignKey(b => b.AuthorId);

            // BlogPostCategory (join table)
            modelBuilder.Entity<BlogPostCategory>()
                .HasKey(bc => new { bc.BlogPostId, bc.CategoryId });
            modelBuilder.Entity<BlogPostCategory>()
                .HasOne(bc => bc.BlogPost)
                .WithMany(b => b.BlogPostCategories)
                .HasForeignKey(bc => bc.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade); // Delete blog post categories when a blog post is deleted
            modelBuilder.Entity<BlogPostCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BlogPostCategories)
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Delete blog post categories when a category is deleted

            // Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.BlogPost)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogPostId)
                .OnDelete(DeleteBehavior.Restrict); // Delete comments when a blog post is deleted
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany() // IdentityUser doesn't have a collection of Comments by default
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // Delete comments when a user is deleted

            // Like
            modelBuilder.Entity<Like>()
                .HasOne(l => l.BlogPost)
                .WithMany(b => b.Likes)
                .HasForeignKey(l => l.BlogPostId)
                .OnDelete(DeleteBehavior.Restrict); // Delete likes when a blog post is deleted
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Author)
                .WithMany() // IdentityUser doesn't have a collection of Likes by default
                .HasForeignKey(l => l.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // Delete likes when a user is deleted



            //Configurations 
            //Make Title and Content required in BlogPost
            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Title)
                .IsRequired();
            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Content)
                .IsRequired();

            // Example: Set maximum lengths for string properties
            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Title)
                .HasMaxLength(200);

        }
    }
}
