using System.Xml.Linq;

namespace DataAccessLayer.Models
{
    public class User
    {
        public User()
        {
            Username = "default";
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

    }
}
