using EfCoreTest.DataAccess;
using EfCoreTest.Models;

namespace EfCoreTest.Services
{
    public class UserService
    {
        private readonly JsonDataAccess _dataAccess;
        private readonly string _dataKey = "Users";

        public UserService(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<User> GetAllUsers()
        {
            var data = _dataAccess.ReadData<Dictionary<string, List<User>>>();
            return data?[_dataKey] ?? new List<User>();
        }

        public User? GetUserById(int id)
        {
            return GetAllUsers().FirstOrDefault(u => u.UserId == id);
        }

        public User AddUser(User newUser)
        {
            var users = GetAllUsers();
            newUser.UserId = users.Any() ? users.Max(u => u.UserId) + 1 : 1;
            users.Add(newUser);

            SaveUsers(users);
            return newUser;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            var users = GetAllUsers();
            var existingUser = users.FirstOrDefault(u => u.UserId == id);
            if (existingUser == null)
                return false;

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.DateCreated = updatedUser.DateCreated;

            SaveUsers(users);
            return true;
        }

        public bool DeleteUser(int id)
        {
            var users = GetAllUsers();
            var userToRemove = users.FirstOrDefault(u => u.UserId == id);
            if (userToRemove == null)
                return false;

            users.Remove(userToRemove);
            SaveUsers(users);
            return true;
        }

        private void SaveUsers(List<User> users)
        {
            var data = _dataAccess.ReadData<Dictionary<string, object>>() ?? new Dictionary<string, object>();
            data[_dataKey] = users;
            _dataAccess.WriteData(data);
        }
    }
}
