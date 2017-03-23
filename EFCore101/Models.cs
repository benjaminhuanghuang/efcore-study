using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFCore101.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        [MaxLength(200)]
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
}