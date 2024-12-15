using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IUserService
    {
        int AddNewUser(DTOs.UserDTO user);
        void DeleteUser(int ID);
        List<User> GetAllUsers();
        User GetUserByID(int id);
    }
}