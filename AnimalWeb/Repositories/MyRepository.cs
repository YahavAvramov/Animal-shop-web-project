using AnimalWeb.Models;
using AnimalWeb.Data;

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
            return _context.Animals.Where(x => x.Category.Name == Category);
        }
        public IEnumerable<Categories> GetCategories()
        {
            return _context.Categories!;
        }
        public string GetCategoryById(int Id)
        {
            return _context.Categories.Single(x => x.ID == Id).Name.ToString();
        }
        public IEnumerable<Comments> GetComments()
        {
            return _context.Comments!;
        }

        public void InsertAnimal(Animals animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animals animal)
        {
            var animalInDb = _context.Animals!.Single(m => m.ID == id);
            animalInDb.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.PictureName = animal.PictureName;
            animalInDb.Description = animal.Description;
            animalInDb.Price = animal.Price;
            _context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals!.Single(m => m.ID == id);
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }
        public void InsertCategory(Categories category)
        {
            _context.Categories!.Add(category);
            _context.SaveChanges();
        }
        public void DeleteCategoty(int id)
        {
            var category = _context.Categories!.Single(m => m.ID == id);
            _context.Categories!.Remove(category);
            _context.SaveChanges();
        }
        public void InsertComment(Comments comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }
       
    }
}

