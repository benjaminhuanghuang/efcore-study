using System;
using System.Linq;

using EFCore101.Models;

namespace EFCore101
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = @"server=127.0.0.1;Database=EFCore101;User Id=sa;Password=Sql@1433";
            //var connStr = config["Data:Blog:ConnectionString"]
            using (var db = new BloggingContext(connStr))
            {
                db.Database.EnsureCreated();

                var blog = new Blog{
                    Name = "The Dog Blog",
                    Url = "The Dog Blog http://"
                };
                db.Blogs.Add(blog);
                db.SaveChanges();

                var blogs = db.Blogs
                            .OrderBy(b => b.Name)
                            .ToList();
                foreach (var item in blogs)
                {
                    Console.WriteLine(item.Name);
                }
            }

            PrintMappings();
        }

        private static void PrintMappings()
        {
            using (var db = new BloggingContext())
            {
                foreach(var item in db.Model.GetEntityTypes())
                {
                    Console.WriteLine($"{item.ClrType.Name} => {item.Model}");
                }
            }
        }
    }
}
