using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Entitis
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Duty> Duties { get; set; }
        public User(int id, string username, string password, string email)
        {
            Id = id;
            UserName = username;
            Password = password;
            Email = email;
        }
        public User()
        {

        }
    }
}
