using Microsoft.AspNetCore.Http.HttpResults;
using UserManagementApp.Models;

namespace UserManagementApp.Services
{
    public class UserService 
    {
        private readonly List<User> users = new();

        public UserService()
        {
            users.Add(new User {Id=1,Name="Ali",Email="ali@gmail.com",Role="admin"});
            users.Add(new User { Id = 2, Name = "Rukuia", Email = "rukuia@gmail.com", Role = "user" });
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User GetById(int id) => users.Find(u => u.Id == id);
        
        public void AddUser(User user)
        {
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            var existingUser = GetById(user.Id);
            if (existingUser == null)
            {
                // Логируем ошибку или обрабатываем ее иначе
                Console.WriteLine($"User with ID {user.Id} not found.");
                return;
            }

            // Обновляем данные пользователя
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
        }


        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                users.Remove(user);
            }
            else
            {
                throw new Exception($"User with ID {user.Id} not found.");
            }
        }
    }
}
