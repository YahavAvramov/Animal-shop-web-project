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
        public void AddComment(string comment, int Id)
        {
            Comments comments = new Comments();
            comments.Comment = comment;
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
            var animalsArry = GetBestAnimalsByArry();
            for (int i = 0; i < animalsArry.Length; i++)
            {
                animals.Add (animalsArry[i]);
            }
            return animals;
        }

        public Animals[] GetBestAnimalsByArry()
        {
            Animals tmp1 = new Animals();
            Animals tmp2 = new Animals();
            int firsPlace = 0, seconedPlace = 0, therdPlade = 0;
            Animals[] animalsToReturn = new Animals[3];
            IEnumerable<Animals> animals = _context.Animals;
            Animals[] arrAnimals = new Animals[_context.Animals.Count()];
            int num = 0;
            foreach (var animal in animals)
            {
                arrAnimals[num] = animal;
                ++num;
            }
            for (int i = 0; i < arrAnimals.Length; i++)
            {
                if (i == 0) { animalsToReturn[i] = arrAnimals[i]; firsPlace = arrAnimals[i].Comments.Count(); }//when it is the firs animal to check
                else
                {
                    if (arrAnimals[i].Comments.Count() > firsPlace)// if the corrent animal comment is bigger then the first place
                    {
                        tmp1 = animalsToReturn[0]; // save the animal in first place 
                        tmp2 = animalsToReturn[1];

                        animalsToReturn[0] = arrAnimals[i]; // make the corent animal first place and orgnize the line
                        animalsToReturn[1] = tmp1;
                        animalsToReturn[2] = tmp2;

                        firsPlace = animalsToReturn[0].Comments.Count();
                        seconedPlace = animalsToReturn[1].Comments.Count();
                        therdPlade = animalsToReturn[2].Comments.Count();

                    }
                    else if (arrAnimals[i].Comments.Count() > seconedPlace)
                    {
                        tmp2 = animalsToReturn[1];

                        animalsToReturn[1] = arrAnimals[i];
                        animalsToReturn[2] = tmp2;

                        seconedPlace = animalsToReturn[1].Comments.Count();
                        therdPlade = animalsToReturn[2].Comments.Count();

                    }
                    else if (arrAnimals[i].Comments.Count() > therdPlade)
                    {
                        animalsToReturn[2] = arrAnimals[i];
                        therdPlade = animalsToReturn[2].Comments.Count();

                    }
                }
            }
            return animalsToReturn;
        }
    }
}

