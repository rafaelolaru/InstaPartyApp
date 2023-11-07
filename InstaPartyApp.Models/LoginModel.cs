using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaPartyApp.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; } // Be careful with plain-text passwords; always use secure handling for them.
    }
}
