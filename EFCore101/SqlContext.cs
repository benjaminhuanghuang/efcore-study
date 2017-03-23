using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFCore101.Models
{
    public class BloggingContext: DbContext
    {
        public DbSet<Blog> Blogs{get; set;}
        public DbSet<Post> Posts{get; set;}
        private readonly string _connString;
        
        public BloggingContext()
        {
            _connString = @"server=127.0.0.1;Database=EFCore101;User Id=sa;Password=Sql@1433";
        }

        public BloggingContext(string connString)
        {
            _connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder moderbuilder)
        {
            // Customize table name
            moderbuilder.Entity<Blog>().ToTable("tbl_blogs");

            // Customize fields
            foreach (var entity in moderbuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = "tbl_" + entity.ClrType.Name;
                foreach(var prop in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    prop.SetMaxLength(200);
                }
                foreach(var fk in entity.GetForeignKeys())
                {
                    fk.Relational().Name = fk.Relational().Name.ToLower();
                }
            }
        }
    }
}