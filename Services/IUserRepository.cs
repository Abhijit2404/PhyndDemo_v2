using System.Collections.Generic;
using System.Threading.Tasks;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public interface IUserRepository{

        IEnumerable<User> GetUsers();
        IEnumerable<Hospital> GetHospitals();
        User GetUser(int Id);
        void AddUser(User User);
        void DeleteUser(User User);
        void UpdateUser(User User);
        int GetUserRole(int id);
        Task<User> LoginUser(string email, string pass);
        IEnumerable<User> GetUsers(Params userParams);
        bool CheckEmail(string Email);
        bool Save();
    }
}