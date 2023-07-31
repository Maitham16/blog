// create database context
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Post>? Posts { get; set; } 
        public DbSet<Comment>? Comments { get; set; }
    }
}
