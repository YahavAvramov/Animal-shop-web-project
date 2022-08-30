using AnimalWeb.Models;

namespace AnimalWeb.Repositories
{
    public interface IUserRepository
    {
        bool CheckUser(string userName, string password);
        //IEnumerable<UserAdmin> IsAdmin(Users user);
        IEnumerable<Users> GetUsers();

    }
}
