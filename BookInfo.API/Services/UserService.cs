using BookInfo.API.DbContext;
using BookInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace BookInfo.API.Services
{
    public class UserService
    {
        private readonly BookContextInfo _bookContextInfo;

        public UserService(BookContextInfo bookContextInfo)
        {
            _bookContextInfo = bookContextInfo;
        }

        public async Task CreateUser(
            string userName, string password, string firstName,
            string lastName, string book)
        {
            // Check if the user already exists
            var existingUser = _bookContextInfo.Users
                .FirstOrDefault(u => u.UserName == userName);

            if (existingUser != null) 
            {
                throw new Exception("This user exists already");
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Create a new user
            var user = new User(userName, 
                hashedPassword, firstName, lastName, book)
            {
                UserName = userName,
                Password = hashedPassword,
                FirstName = firstName,
                LastName = lastName,
                Book = book,
            };

            try
            {
                // Add the user to the database and save changes
                _bookContextInfo.Users.Add(user);
                await _bookContextInfo.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the error message and rethrow the exception
                Console.WriteLine($"An error occurred while saving changes: {ex.InnerException.Message}");
                throw;
            }
        }

        //public User ValidateUserCredentials(string username, string password)
        //{
        //    var user = _bookContextInfo.Users.FirstOrDefault(u => u.UserName == username);

        //    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        //    {
        //        return user;
        //    }

        //    return null;
        //}
    }
}
