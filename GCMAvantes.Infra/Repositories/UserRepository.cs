using GCMAvantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMAvantes.Infra.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role="manager" });
            users.Add(new User { Id = 1, Username = "robin", Password = "robin", Role = "employee" });

           return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).First();



        }
    }
}
