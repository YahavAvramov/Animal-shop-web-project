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
        public IEnumerable<Comments> GetCommentsById(int Id)
        {
            return _context.Comments.Where(x => x.Animal.ID == Id);
        }
        public void CreateAnimal(string name, int age, int price, string description, string pictureName, string categoryName)
        {
            Animals animal = new Animals();
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
        public void AddComment(string comment, string name , int animalId)
        {

            Animals animal = GetAnimalById(animalId);
            Comments comments = new Comments
            {

                AnimalID = animalId,
                Animal = animal,
                Comment = comment,
                CommentWriterName = name,
                CommentDate = DateTime.Now

            };
       
            _context.Comments!.Add(comments);
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
        public IEnumerable<Animals> GetBestAnimals()
        {
            List<Animals> animals = new List<Animals>();
            var animalsArry = GetAnimalByComments();
            for (int i = 0; i < animalsArry.Length ; i++)
            {
                var firstAnimal = _context.Animals.Where(a => a.ID == animalsArry[i] + 1).First();
                animals.Add(firstAnimal);
            }   
            return animals;
        }
        public int[] GetAnimalByComments()
        {
            int[] tempArray = new int[_context.Animals.Count()];
            var index = 0;
            foreach (var item in _context.Animals)
            {
                var temp = _context.Comments.Where(x => x.AnimalID == item.ID);
                tempArray[index++] = temp.Count();
            }
            int[] sortArry = new int[3];
            int maxItem = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (tempArray[i] >= tempArray[maxItem])
                    {
                        maxItem = i;

                    }
                }
                tempArray[maxItem] = -1;
                sortArry[j] = maxItem;
            }
            return sortArry;
        }
       
    }
}


