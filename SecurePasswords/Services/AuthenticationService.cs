using SecurePasswords.DbContexts;
using SecurePasswords.Interfaces;
using SecurePasswords.Models;

namespace SecurePasswords.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserDbContext _dbContext;

        public AuthenticationService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterUser(string username, string password)
        {
            if (_dbContext.Users.Any(u => u.Username == username))
            {
                throw new Exception("Username already exists");
            }

            var newUser = new User
            {
                Username = username
            };

            newUser.SetPassword(password);

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public bool AuthenticateUser(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return false;
            }

            return user.VerifyPassword(password);
        }
    }
}