using HW_week_12.DbContect;
using HW_week_12.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public User Login(string username, string password)
        {
            var users = _appDbContext.Users.FirstOrDefault(t => t.UserName == username);
            if (users != null)
            {
                return new User { UserName = username, Password = password };
            }
            return users;
        }

        public string Register(User user)
        {
            var username = _appDbContext.Users.FirstOrDefault(t => t.UserName == user.UserName);
            if (username != null)
            {
                return "User Already Exist";
            }
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return "Registerred Successful";
        }
    }
}
