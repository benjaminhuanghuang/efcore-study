using Microsoft.EntityFrameworkCore;

namespace EFCore101.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url {get;set;}
    }

    public class Post
    {
        public  int PostId { get; set; }
        public string Title { get; set; }
        public string Content {get;set;}

        public int BlogId{get; set;}
        public Blog Blog {get; set;}
    }

    public class BloggingContext: DbContext
    {
        public DbSet<Blog> Blogs{get; set;}
        public DbSet<Post> Posts{get; set;}
        private readonly string _connString;
        
        public BloggingContext(string connString)
        {
            _connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}