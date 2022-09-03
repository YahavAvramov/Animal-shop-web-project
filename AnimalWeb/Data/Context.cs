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

        public DbSet<Users> Users { get; set; }
        //public DbSet<UserAdmin> Admins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animals>().HasOne(a => a.Category).WithMany(c => c.Animals);
            modelBuilder.Entity<Comments>().HasOne(a => a.Animal).WithMany(c => c.Comments);

            modelBuilder.Entity<Categories>().HasData(
                new { ID = 1, Name = "Dogs", CategoryPicture = @"\Assets\CategoriesI-icons\dog-icon.webp" },
                new { ID = 2, Name = "Cats", CategoryPicture = @"\Assets\CategoriesI-icons\cat-icon.webp" },
                new { ID = 3, Name = "Fish", CategoryPicture = @"\Assets\CategoriesI-icons\fish-icon.webp" },
                new { ID = 4, Name = "Rabbits", CategoryPicture = @"\Assets\CategoriesI-icons\rabbit-icon.jpg" },
                new { ID = 5, Name = "Iguanas", CategoryPicture = @"\Assets\CategoriesI-icons\iguana-icon.jpg" }
            );
            modelBuilder.Entity<Animals>().HasData(
                new { Name = "Rex", Age = 1, PictureName = "Path", Description = "lorem50", CategoryName = "Dogs", Price = 10},
                new { Name = "Miki", Age = 2, PictureName = "Path", Description = "lorem50", CategoryName = "Dogs", Price = 23},
                new { Name = "Hatul", Age = 3, PictureName = "Path", Description = "lorem50", CategoryName = "Cats", Price = 11 },
                new { Name = "Nemo", Age = 3, PictureName = "Path", Description = "lorem50", CategoryName = "Fish", Price = 22 },
                new { Name = "Bunni", Age = 3, PictureName = "Path", Description = "lorem50", CategoryName = "Rabbits", Price = 2 },
                new { Name = "Baks", Age = 3, PictureName = "Path", Description = "lorem50", CategoryName = "Rabbits", Price = 13 },
                new { Name = "Ziki", Age = 3, PictureName = "Path", Description = "lorem50", CategoryName = "Iguanas", Price = 15 },
                new { Name = "Ziko", Age = 3, PictureName = "Path", Description = "lorem50", CategoryName = "Iguanas", Price = 10 }
            );  
            modelBuilder.Entity<Comments>().HasData(
                new { ID = 1, Comment = "Dogs", AnimalID = 1}
            );
            //modelBuilder.Entity<Users>().HasData(
            //    new { ID = 1, Comment = "Dogs", AnimalID = 1 }
            //);
            //modelBuilder.Entity<UserAdmin>().HasData(
            //    new { ID = 1, Comment = "Dogs", AnimalID = 1 }
            //);

            modelBuilder.Entity<Users>().HasData(
                new {ID= 1,  Email = "yahav99999@gmail.com", Password = "123456" },
                new {ID=2 ,  Email = "maxim@gmail.com", Password = "1" },
                new {ID= 3 , Email = "admin@gmail.com", Password = "246810" });
    

        }

    }
}
