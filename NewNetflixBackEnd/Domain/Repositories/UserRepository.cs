using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserRepository
    {
        NewNetflixContext context;

        public UserRepository()
        {
            context = new NewNetflixContext();
        }

        public User Add(User user )
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public bool Delete(int id)
        {
            var users = GetById(id);

            if (users.UsrId > 0)
            {
                context.Users.Remove(users);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public User GetById(int id) => context.Users.Find(id);

        public User Update(User user)
        {
            var userUp = GetById(user.UsrId);
            context.Entry(userUp).CurrentValues.SetValues(user);
            context.SaveChanges();
            return userUp;
        }

        public IEnumerable<User> GetAll() => context.Users.ToList();

       
        //select * from movies

    }
}
