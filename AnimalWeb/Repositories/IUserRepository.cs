using AnimalWeb.Models;

namespace AnimalWeb.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<Users>GetUser(string userName, string password);
        IEnumerable<UserAdmin> IsAdmin(Users user);

    }
}
