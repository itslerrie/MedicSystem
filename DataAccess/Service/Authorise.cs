using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class Authorise
    {
        public User LoggedUser { get; private set; }

        public void Authenticate(string Email, string Password)
        {
            UserRepo userRepo = new UserRepo();

            List<User> users = userRepo.GetAll(u => u.Email == Email && u.Password == Password).ToList();

            LoggedUser = users.Count > 0 ? users[0] : null;
        }
    }
}
