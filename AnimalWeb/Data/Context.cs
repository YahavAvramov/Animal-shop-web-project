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
                new { ID = 1, Name = "Rex", Age = 1, PictureName = @"\Assets\PetsFolder\Rex.jpg", Description = "Rex is a very friendly dog, he likes to play with ball and really love toys", CategoryName = "Dogs", Price = 10 },
                new { ID = 2, Name = "Miki", Age = 2, PictureName = @"\Assets\PetsFolder\Miki.jpg", Description = "lorem50", CategoryName = "Dogs", Price = 23 },
                new { ID = 3, Name = "Hatul", Age = 3, PictureName = @"\Assets\PetsFolder\Hatul.jpg", Description = "lorem50", CategoryName = "Cats", Price = 11 },
                new { ID = 4, Name = "Nemo", Age = 3, PictureName = @"\Assets\PetsFolder\Nemo.jpg", Description = "lorem50", CategoryName = "Fish", Price = 22 },
                new { ID = 5, Name = "Bunni", Age = 3, PictureName = @"\Assets\PetsFolder\Bunni.jpg", Description = "lorem50", CategoryName = "Rabbits", Price = 2 },
                new { ID = 6, Name = "Baks", Age = 3, PictureName = @"\Assets\PetsFolder\Baks.jpg", Description = "lorem50", CategoryName = "Rabbits", Price = 13 },
                new { ID = 7, Name = "Ziki", Age = 3, PictureName = @"\Assets\PetsFolder\Ziki.jpg", Description = "lorem50", CategoryName = "Iguanas", Price = 15 },
                new { ID = 8, Name = "Ziko", Age = 3, PictureName = @"\Assets\PetsFolder\Ziko.jpg", Description = "lorem50", CategoryName = "Iguanas", Price = 10 }
            );
            modelBuilder.Entity<Comments>().HasData(
                new { ID = 1, Comment = "I will buy that dog!", AnimalID = 1, CommentWriterName = "shir", CommentDate = DateTime.Now },
                new { ID = 2, Comment = "what a cuty", AnimalID = 1, CommentWriterName = "david", CommentDate = DateTime.Now },
                new { ID = 3, Comment = "i want one", AnimalID = 1, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new { ID = 4, Comment = "lets buy it", AnimalID = 1, CommentWriterName = "sapir", CommentDate = DateTime.Now },
                new { ID = 5, Comment = "what a cuty", AnimalID = 2, CommentWriterName = "david", CommentDate = DateTime.Now },
                new { ID = 6, Comment = "i want one", AnimalID = 2, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new { ID = 7, Comment = "lets buy it", AnimalID = 3, CommentWriterName = "sapir", CommentDate = DateTime.Now },
                new { ID = 8, Comment = "what a cuty", AnimalID = 5, CommentWriterName = "david", CommentDate = DateTime.Now },
                new { ID = 9, Comment = "i want one", AnimalID = 5, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new { ID = 10, Comment = "lets buy it", AnimalID = 5, CommentWriterName = "sapir", CommentDate = DateTime.Now }
            );
            //modelBuilder.Entity<Users>().HasData(
            //    new { ID = 1, Comment = "Dogs", AnimalID = 1 }
            //);
            //modelBuilder.Entity<UserAdmin>().HasData(
            //    new { ID = 1, Comment = "Dogs", AnimalID = 1 }
            //);

            modelBuilder.Entity<Users>().HasData(
                new { ID = 1, Email = "yahav99999@gmail.com", Password = "123456" },
                new { ID = 2, Email = "maxim@gmail.com", Password = "1" },
                new { ID = 3, Email = "admin@gmail.com", Password = "246810" });


        }

    }
}
