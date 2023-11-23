using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;

namespace InstaPartyApp.Services
{
    public interface IAuthService
    {
        User ValidateUser(string username, string password);
        User CreateUser(string username, string password);
        object GetUserByUsername(object username);
    }

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public User ValidateUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
 

            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public User CreateUser(string username, string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            
            var user = new User { Username = username, PasswordHash = hashedPassword };
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public object GetUserByUsername(object username)
        {
            return _context.Users
                           .AsNoTracking()
                           .FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
