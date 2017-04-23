using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFCore101.Models
{
    public class NoteContext: DbContext
    {
        public DbSet<Blog> Blogs{get; set;}
        public DbSet<Post> Posts{get; set;}
        
        public NoteContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Notes.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}