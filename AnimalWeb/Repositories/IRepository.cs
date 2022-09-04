using AnimalWeb.Models;

namespace AnimalWeb.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animals> GetAnimals();
        IEnumerable<Animals> GetAnimalsByCategory(string category);
        IEnumerable<Categories> GetCategories();
        string GetCategoryById(int Id);
        IEnumerable<Comments> GetCommentsById(int Id);
        void AddComment(string comment, int Id);
        void CreateAnimal(string name, int age, int price, string description, string pictureName, string categoryName);
        void UpdateAnimal( string name , int age , int price , string description , string pictureURL, int id );
        void DeleteAnimal(int id);
        void DeleteCategoty(string categoryName);
        void CreateCategory(string name , string categoryURLpictuer);
        Animals GetAnimalById(int id);
        public IEnumerable<Animals> GetBestAnimals();
        public int[] GetAnimalByComments();
    }
}
