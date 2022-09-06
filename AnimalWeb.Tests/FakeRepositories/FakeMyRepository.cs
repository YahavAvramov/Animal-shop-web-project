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
            throw new NotImplementedException();
        }

        IEnumerable<Animals> IRepository.GetBestAnimals()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Categories> IRepository.GetCategories()
        {
            throw new NotImplementedException();
        }

        string IRepository.GetCategoryById(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Comments> IRepository.GetCommentsById(int Id)
        {
            throw new NotImplementedException();
        }

        void IRepository.UpdateAnimal(string name, int age, int price, string description, string pictureURL, int id)
        {
            throw new NotImplementedException();
        }
    }
}
