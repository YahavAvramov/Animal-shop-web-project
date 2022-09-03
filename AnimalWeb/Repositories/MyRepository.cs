using AnimalWeb.Models;
using AnimalWeb.Data;
using System.Data.Entity;

namespace AnimalWeb.Repositories
{
    public class MyRepository : IRepository
    {
        private Context _context;

        public MyRepository(Context context)
        {
            _context = context; 
        }


        public IEnumerable<Animals> GetAnimals()
        {
            return _context.Animals!;
        }
        public IEnumerable<Animals> GetAnimalsByCategory(string Category)
        {
            return _context.Animals.Where(x => x.CategoryName == Category);
        }
        public IEnumerable<Categories> GetCategories()
        {
            return _context.Categories!;
        }
        public string GetCategoryById(int Id)
        {
            return _context.Animals.Single(x => x.ID == Id).CategoryName;
        }
        public IEnumerable<Comments> GetComments()
        {
            return _context.Comments!;
        }

        public void CreateAnimal(string name, int age, int price, string description, string pictureName, string categoryName)
        {
            int id = 9;
            Animals animal = new Animals();
            animal.ID = id;
            animal.Name = name;
            animal.Age = age;
            animal.Price = price;
            animal.Description = description;
            animal.PictureName = pictureName;
            animal.CategoryName = categoryName;
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(string name, int age, int price, string description, string pictureURL, int id)
        {
            var animalInDb = _context.Animals!.Single(m => m.ID == id);
            animalInDb.Name = name;
            animalInDb.Age = age;
            animalInDb.PictureName = pictureURL;
            animalInDb.Description = description;
            animalInDb.Price = price;
            _context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals!.Single(m => m.ID == id);
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }
        public void DeleteCategoty(string categoryName)
        {
            var category = _context.Categories!.Single(m => m.Name == categoryName);
            _context.Categories!.Remove(category);
            _context.SaveChanges();
        }
        public void InsertComment(Comments comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

        public void CreateCategory(string name, string categoryURLpictuer)
        {
            Categories newCategory = new Categories();
            newCategory.Name = name;
            newCategory.CategoryPicture = categoryURLpictuer;
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }


        public Animals GetAnimalById(int id)
        {
            return _context.Animals.Where(a => a.ID == id).First();
        }
    }
}

