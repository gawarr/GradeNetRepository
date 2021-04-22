using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class UserModel
    {
        public int UserId      { get; set; }
        public string Email    { get; set; }
        public string Password { get; set; }
        public string Cassword { get; set; }

        public UserModel()
        {

        }

        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
