using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public enum TypeUser
    {
        administrator = 1,
        user = 2,
    }
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string ProfileImage { get; set; }
        public TypeUser TypeUser { get; set; }
        public bool IsAdmin { get; set; }

        public User() { }

        public User(string email, string password, bool administrator)
        {
            Email = email;
            Password = password;

            TypeUser = IsAdmin ? TypeUser.administrator : TypeUser.user;
        }
    }
}
