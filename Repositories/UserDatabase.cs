using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPINotebook.Models;

namespace WebAPINotebook.Repositories
{
    public class UserDatabase
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "Fagner", Password = "Fagner", Role = "gerente" });
            users.Add(new User { Id = 2, Username = "Nilson", Password = "Nilson", Role = "empregado" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
