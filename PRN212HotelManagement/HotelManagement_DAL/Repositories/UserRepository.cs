using HotelManagement_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement_DAL.Repositories
{
    public class UserRepository
    {
        private Prn212hotelManagementContext _prn212hotelManagementContext;

        public UserRepository(Prn212hotelManagementContext prn212hotelManagementContext)
        {
            _prn212hotelManagementContext = prn212hotelManagementContext;
        }

        public User? GetUserByEmail(string email)
        {
            return _prn212hotelManagementContext.Users.FirstOrDefault(u => u.UserEmail == email);
        }
        public User? GetUserByUserName(string username)
        {
            return _prn212hotelManagementContext.Users.FirstOrDefault(u => u.UserName == username);
        }
        public bool AddUser(User user)
        {
            var existingUser = _prn212hotelManagementContext.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail || u.UserName == user.UserName);

            if (existingUser != null)
            {
                return false;
            }

            _prn212hotelManagementContext.Users.Add(user);
            _prn212hotelManagementContext.SaveChanges();
            return true;
        }
        public List<User> GetAllUsers()
        {
            return _prn212hotelManagementContext.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            var existingUser = _prn212hotelManagementContext.Users.FirstOrDefault(u => u.UserId == user.UserId);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.UserName = user.UserName;
            existingUser.UserEmail = user.UserEmail;
            existingUser.UserPassword = user.UserPassword;
            existingUser.UserPhone = user.UserPhone;
            existingUser.UserRole = user.UserRole;

            _prn212hotelManagementContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var user = _prn212hotelManagementContext.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                return false;
            }

            _prn212hotelManagementContext.Users.Remove(user);
            _prn212hotelManagementContext.SaveChanges();
            return true;
        }

        public void Add(User user)
        {
            _prn212hotelManagementContext.Users.Add(user);
        }

        public void SaveChanges()
        {
            _prn212hotelManagementContext.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return _prn212hotelManagementContext.Users;
        }
    }
}
