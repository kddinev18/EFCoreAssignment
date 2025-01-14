using EfCoreTest.DataAccess;
using EfCoreTest.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService()
        {
            _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (existingUser == null)
                return false;

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var userToRemove = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (userToRemove == null)
                return false;

            _context.Users.Remove(userToRemove);
            _context.SaveChanges();
            return true;
        }
    }
}
