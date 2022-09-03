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
        void CreateAnimal(string name, int age, int price, string description, string pictureName, string categoryName);
        void UpdateAnimal( string name , int age , int price , string description , string pictureURL, int id );
        void DeleteAnimal(int id);
        void DeleteCategoty(string categoryName);
        void InsertComment(Comments comment);
        void CreateCategory(string name , string categoryURLpictuer);
        Animals GetAnimalById(int id);  
    }
}
