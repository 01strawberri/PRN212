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
    }
}
