using HW_week_12.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Service
{
    public interface IUserService
    {
        public string Register(User user);
        public User Login(string username, string password);
    }
}
