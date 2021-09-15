using System.Collections.Generic;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public interface IUserRepository{

        IEnumerable<User> GetUsers();
        User GetUser(int Id);
        void AddUser(User User);
        void DeleteUser(User User);
        void UpdateUser(User User);
        User LoginUser(string email, string pass);
        IEnumerable<User> GetUsers(Params userParams);
        bool UserExists(int Id);
        bool Save();
    }
}