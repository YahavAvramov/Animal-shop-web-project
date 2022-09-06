using AnimalWeb.Models;
using AnimalWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWeb.Tests.FakeRepositories
{
    public class FakeMyRepository : IRepository
    {
        void IRepository.AddComment(string comment, string name, int animalId)
        {
            throw new NotImplementedException();
        }

        void IRepository.CreateAnimal(string name, int age, int price, string description, string pictureName, string categoryName)
        {
            throw new NotImplementedException();
        }

        void IRepository.CreateCategory(string name, string categoryURLpictuer)
        {
            throw new NotImplementedException();
        }

        void IRepository.DeleteAnimal(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository.DeleteCategoty(string categoryName)
        {
            throw new NotImplementedException();
        }

        void IRepository.DeleteComment(int id, int animalId)
        {
            throw new NotImplementedException();
        }

        int[] IRepository.GetAnimalByComments()
        {
            throw new NotImplementedException();
        }

        Animals IRepository.GetAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Animals> IRepository.GetAnimals()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Animals> IRepository.GetAnimalsByCategory(string category)
        {
            IEnumerable<Animals> animals = new List<Animals>
            {
            new Animals { ID = 1, Name = "Rex", Age = 1, PictureName = @"\Assets\Pets\Dogs\Rex.jpg", Description = "Rex is a very friendly dog, he likes to play with ball and really love toys", CategoryName = "Dogs", Price = 120 },
            new Animals { ID = 2, Name = "Mickey", Age = 2, PictureName = @"\Assets\Pets\Dogs\Miki.jpg", Description = "Mickey is a dog full of energy, happy and bouncy who will always be happy to play with you", CategoryName = "Dogs", Price = 93 },
            new Animals { ID = 3, Name = "Snow", Age = 3, PictureName = @"\Assets\Pets\Cats\Snow.jpg", Description = "Calm and always loves cuddling", CategoryName = "Cats", Price = 11 }
            };
            return animals;
        }

        IEnumerable<Animals> IRepository.GetBestAnimals()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Categories> IRepository.GetCategories()
        {
            IEnumerable<Categories> categories = new List<Categories>
            {
            new Categories { ID = 1, Name = "Dogs", CategoryPicture = @"\Assets\CategoriesI-icons\dog-icon.webp" },
            new Categories { ID = 2, Name = "Cats", CategoryPicture = @"\Assets\CategoriesI-icons\cat-icon.webp" }
            };
            return categories;
        }

        string IRepository.GetCategoryById(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Comments> IRepository.GetCommentsById(int Id)
        {
            IEnumerable<Comments> comments = new List<Comments>
            {
                new Comments { ID = 1, Comment = "I will buy that dog!", AnimalID = 1, CommentWriterName = "shir", CommentDate = DateTime.Now },
                new Comments { ID = 2, Comment = "What a cuty", AnimalID = 1, CommentWriterName = "david", CommentDate = DateTime.Now },
                new Comments { ID = 3, Comment = "I want one", AnimalID = 1, CommentWriterName = "omer", CommentDate = DateTime.Now },
                new Comments { ID = 4, Comment = "Lets buy it", AnimalID = 1, CommentWriterName = "sapir", CommentDate = DateTime.Now },
                new Comments { ID = 5, Comment = "What a cuty", AnimalID = 2, CommentWriterName = "david", CommentDate = DateTime.Now },
                new Comments { ID = 6, Comment = "I want one", AnimalID = 2, CommentWriterName = "omer", CommentDate = DateTime.Now }
            };

            return comments;
        }

        void IRepository.UpdateAnimal(string name, int age, int price, string description, string pictureURL, int id)
        {
            throw new NotImplementedException();
        }
    }
}
