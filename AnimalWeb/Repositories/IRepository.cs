using AnimalWeb.Models;

namespace AnimalWeb.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animals> GetAnimals();
        IEnumerable<Animals> GetAnimalsByCategory(string category);
        IEnumerable<Categories> GetCategories();
        string GetCategoryById(int Id);
        IEnumerable<Comments> GetComments();
        void InsertAnimal(Animals animal);
        void UpdateAnimal(int id, Animals animal);
        void DeleteAnimal(int id);
        void InsertCategory(Categories category);
        void DeleteCategoty(int id);
        void InsertComment(Comments comment);
    }
}
