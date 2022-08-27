using AnimalWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace AnimalWeb.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new { ID = 1, Name = "Dogs", CategoryPicture = "Path" },
                new { ID = 2, Name = "Cats", CategoryPicture = "Path" },
                new { ID = 3, Name = "Fish", CategoryPicture = "Path" },
                new { ID = 4, Name = "rabbit", CategoryPicture = "Path" }
            );
            modelBuilder.Entity<Animals>().HasData(
                new { ID = 1, Name = "Rex", Age = 1, PictureName = "Path", Description = "lorem50", CategoryID = 1, Price = 10},
                new { ID = 2, Name = "Miki", Age = 2, PictureName = "Path", Description = "lorem50", CategoryID = 1, Price = 10},
                new { ID = 3, Name = "Hatul", Age = 3, PictureName = "Path", Description = "lorem50", CategoryID = 2, Price = 10}
            );  
            modelBuilder.Entity<Comments>().HasData(
                new { ID = 1, Comment = "Dogs", AnimalID = 1}
            );

        }

    }
}
