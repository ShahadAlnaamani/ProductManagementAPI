using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}