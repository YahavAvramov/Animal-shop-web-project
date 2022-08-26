using AnimalWeb.Models;

namespace AnimalWeb.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animals> GetAnimals();
        IEnumerable<Categories> GetCategories();
        IEnumerable<Comments> GetComments();
        void InsertAnimal(Animals animal);
        void UpdateAnimal(int id, Animals animal);
        void DeleteAnimal(int id);
        void InsertCategory(Categories category);
        void DeleteCategoty(int id);
        void InsertComment(Comments comment);
    }
}
