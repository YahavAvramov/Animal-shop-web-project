using AnimalWeb.Data;
using AnimalWeb.Models;

namespace AnimalWeb.Repositories
{
    public class MyUserRepository : IUserRepository
    {
        private Context _context;

        public MyUserRepository(Context context)
        {
            _context = context;
        }

        public void AddNewAdmin(string email, string password)
        {
            _context.Users.Add(new Users { Email = email, Password = password });
            _context.SaveChanges();
        }

        public bool CheckUser(string userEmail, string password)
        {
            IEnumerable<Users> users = _context.Users; 

            return (users.Any(u => u.Password == password && u.Email == userEmail));
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users!;
        }
    }
}

