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
        //IEnumerable<Users> GetUser(string userName, string password)
        //{


        //}
        //IEnumerable<UserAdmin> IsAdmin(Users user)
        //{

        //}
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

