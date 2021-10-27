using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public class UserRepository : IUserRepository
    {
        private readonly phynd2Context _context;
        public UserRepository(phynd2Context context)
        {
            _context = context;
        }
        public void AddUser(User User)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }

            _context.Users.Add(User);
        }

        public void DeleteUser(User User)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }

            _context.Users.Remove(User);
        }

        public User GetUser(int Id)
        {
            return _context.Users.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            return _context.Hospitals.ToList<Hospital>();
        }

        public void UpdateUser(User user)
        {
            //DTO Mapping
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<User> LoginUser(string email, string pass)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass)){
                return null;
            }
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == pass);
        }

        public IEnumerable<User> GetUsers(Params userParams)
        {
            if(userParams == null){
                throw new ArgumentNullException(nameof(userParams));
            }

            if(string.IsNullOrWhiteSpace(userParams.sortByFirstName) 
                && string.IsNullOrWhiteSpace(userParams.sortByLastName) 
                && string.IsNullOrWhiteSpace(userParams.Search))
            {
                return GetUsers();
            }

            var collection = _context.Users as IQueryable<User>;
            if(!string.IsNullOrWhiteSpace(userParams.sortByFirstName))
            {
                var firstName = userParams.sortByFirstName.Trim();
                collection = collection.Where(a => a.FirstName == firstName);
            }
            if(!string.IsNullOrWhiteSpace(userParams.sortByLastName)){

                var lastName = userParams.sortByLastName.Trim();
                collection = collection.Where(a => a.LastName == lastName);

            }

            if(!string.IsNullOrWhiteSpace(userParams.Search))
            {
                var search = userParams.Search.Trim();
                return collection.Where(a => a.FirstName.Contains(search) || a.LastName.Contains(search));
            }

            return collection.ToList();
        }
        public bool CheckEmail(string Email)
        {
            return _context.Users.Any(a => a.Email == Email);
        }
    }
}