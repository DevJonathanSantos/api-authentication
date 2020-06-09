using System.Collections.Generic;
using System.Linq;

namespace UserAuthentication.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Name = "batman", Password = "12345" });
            users.Add(new User { Id = 2, Name = "robin", Password = "54321" });
            return users.Where(x => x.Name.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
