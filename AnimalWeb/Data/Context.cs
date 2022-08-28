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
                new { ID = 1, Name = "Dogs", CategoryPicture = "https://cdn.pixabay.com/photo/2018/05/26/18/06/dog-3431913_960_720.jpg" },
                new { ID = 2, Name = "Cats", CategoryPicture = "https://cdn.pixabay.com/photo/2021/04/19/23/01/cat-6192640_960_720.png" },
                new { ID = 3, Name = "Fish", CategoryPicture = "https://cdn.pixabay.com/photo/2020/11/20/16/57/fish-5762191_960_720.png" },
                new { ID = 4, Name = "rabbits", CategoryPicture = "https://media.istockphoto.com/vectors/bunny-head-icon-vector-id1144656871?b=1&k=20&m=1144656871&s=170667a&w=0&h=ewHpDlmi8ExuEOc_SJDPxf5K5ao3wjtumed9TWbJ1UY=" }
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
