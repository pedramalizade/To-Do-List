using HW_week_12.Entitis;
using HW_week_12.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Service
{
    public class UserService : IUserService
    {
        User loggedIn = null;

        private UserRepository userRepo;

        public UserService()
        {
            userRepo = new UserRepository();
        }

        public UserService(UserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public User Login(string username, string password)
        {
            var login = userRepo.Login(username, password);
            loggedIn = login;
            return loggedIn;
        }

        public string Register(User user)
        {
            return userRepo.Register(user);
        }
    }
}
