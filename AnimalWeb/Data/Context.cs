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
                new { ID = 1, Name = "Rex", Age = 1, PictureName = @"\Assets\Pets\Dogs\Rex.jpg", Description = "Rex is a very friendly dog, he likes to play with ball and really love toys", CategoryName = "Dogs", Price = 120 },
                new { ID = 2, Name = "Mickey", Age = 2, PictureName = @"\Assets\Pets\Dogs\Miki.jpg", Description = "Mickey is a dog full of energy, happy and bouncy who will always be happy to play with you", CategoryName = "Dogs", Price = 93 },
                new { ID = 3, Name = "Snow", Age = 3, PictureName = @"\Assets\Pets\Cats\Snow.jpg", Description = "Calm and always loves cuddling", CategoryName = "Cats", Price = 11 },
                new { ID = 4, Name = "Nemo", Age = 3, PictureName = @"\Assets\Pets\Fish\Nemo.jpg", Description = "needs space to swim and lots of hiding places in the aquarium for it to feel comfortable", CategoryName = "Fish", Price = 22 },
                new { ID = 5, Name = "Bunni", Age = 3, PictureName = @"\Assets\Pets\rabbits\Bunni.jpg", Description = "His favorite food is lettuce, can eliminate whole packages in a few hours", CategoryName = "Rabbits", Price = 2 },
                new { ID = 6, Name = "Baks", Age = 3, PictureName = @"\Assets\Pets\rabbits\Baks.jpg", Description = "mainly active at night and in the dark hours", CategoryName = "Rabbits", Price = 13 },
                new { ID = 7, Name = "Ziki", Age = 3, PictureName = @"\Assets\Pets\Iguanas\Ziki.jpg", Description = "A unique type of iguana, amazing in various colors", CategoryName = "Iguanas", Price = 15 },
                new { ID = 8, Name = "Bob", Age = 3, PictureName = @"\Assets\Pets\Iguanas\Bob.jpg", Description = "Not doing much, mostly being lazy", CategoryName = "Iguanas", Price = 10 }
            );
            modelBuilder.Entity<Comments>().HasData(
                new { ID = 1, Comment = "I will buy that dog!", AnimalID = 1, CommentWriterName = "shir", CommentDate = DateTime.Now },
                new { ID = 2, Comment = "What a cuty", AnimalID = 1, CommentWriterName = "david", CommentDate = DateTime.Now },
                new { ID = 3, Comment = "I want one", AnimalID = 1, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new { ID = 4, Comment = "Lets buy it", AnimalID = 1, CommentWriterName = "sapir", CommentDate = DateTime.Now },
                new { ID = 5, Comment = "What a cuty", AnimalID = 2, CommentWriterName = "david", CommentDate = DateTime.Now },
                new { ID = 6, Comment = "I want one", AnimalID = 2, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new { ID = 7, Comment = "Lets buy it", AnimalID = 3, CommentWriterName = "sapir", CommentDate = DateTime.Now },
                new { ID = 8, Comment = "What a cuty", AnimalID = 5, CommentWriterName = "david", CommentDate = DateTime.Now },
                new { ID = 9, Comment = "I want one", AnimalID = 5, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new { ID = 10, Comment = "Lets buy it", AnimalID = 5, CommentWriterName = "sapir", CommentDate = DateTime.Now },
                new { ID = 11, Comment = "What a massive rabbit!", AnimalID = 6, CommentWriterName = "Tom", CommentDate = DateTime.Now }
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
