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

        
    }
}
