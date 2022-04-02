using demo.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.web.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly demoContext _context;

        public UserRepository(demoContext context)
        {
            _context = context;
        }
        //Save a user
        public void SaveUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
        //Returns all users
        public IEnumerable<User> GetAllUsers()
        {
            var users = from u in _context.Users
                        select u;
            return users.ToList();
        }

        //Returns a single user by ID
        public User GetUserByID(int userID)
        {
            var user = (from u in _context.Users
                        where u.Id == userID
                        select u).FirstOrDefault();
            return user;
        }
        //Update a user
        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        //Delete a user
        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        //Save all
        public bool SaveAll()
        {
            //Save changes returns the number of rows affected
            return _context.SaveChanges() > 0;
        }
    }
}
