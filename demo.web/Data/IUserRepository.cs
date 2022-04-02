using demo.web.Data.Entities;
using System.Collections.Generic;

namespace demo.web.Data
{
    public interface IUserRepository
    {
        void DeleteUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int userID);
        void SaveUser(User user);
        void UpdateUser(User user);
        bool SaveAll();
    }
}