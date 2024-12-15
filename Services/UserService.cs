using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public int AddNewUser(UserDTO userDTO)
        {
            var user = new User
            {
                UserName = userDTO.Name,
                Password = userDTO.Password,
            };
            return _userRepository.AddUser(user);
        }


        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers().ToList();
        }


        public User GetUserByID(int id)
        {
            var user = _userRepository.GetUserById(id);

            return user;
        }

        public void DeleteUser(int ID)
        {
            _userRepository.DeleteUser(ID);
        }

        public User GetUser(string uname, string password)
        {
            return _userRepository.GetUser(uname, password);

        }

    }
}
