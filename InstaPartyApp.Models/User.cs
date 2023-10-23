using System.Xml.Linq;

namespace InstaPartyApp.Models
{
    public class User
    {
        public User()
        {
            Username = "default";
        }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
