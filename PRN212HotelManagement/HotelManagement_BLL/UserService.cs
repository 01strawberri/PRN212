using HotelManagement_DAL;
using HotelManagement_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(string username , string password)
        {
            var user = _userRepository.GetUserByUserName(username);

            if (user != null && user.UserPassword == password)
            {
                switch (user.UserRole)
                {
                    case 1:
                        return "Admin";
                    case 2:
                        return "Staff";
                    case 3:
                        return "Customer";
                    default:
                        return "Unknown";
                }
            }
            else
            {
                return "Invalid";
            }
        }
        public bool AccountExists(string email, string username)
        {
            var userByEmail = _userRepository.GetUserByEmail(email);
            var userByUsername = _userRepository.GetUserByUserName(username);

            return userByEmail != null && userByUsername != null;
        }
        public bool Register(string email, string username, string password, string phone)
        {
            var newUser = new User
            {
                UserName = username,
                UserEmail = email,
                UserPassword = password,
                UserPhone = phone,
                CreatedAt = DateTime.Now,
                UserRole = 2
            };
            return _userRepository.AddUser(newUser);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUserName(username);
        }

    }
}
