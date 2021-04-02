using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly UserContext _context;
        public SqlUserRepo(UserContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }
        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            /*
             https://localhost:44346/api/Users
             */
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            /*
             https://localhost:44346/api/Users/5
             */
            var user = _context.Users.FirstOrDefault(x=>x.Id==id);
            return user;
        }

        public void PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {

        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void UpdateUser(int id,User user)
        {
            var userFromDB = _context.Users.FirstOrDefault(x => x.Id == id);
            userFromDB.Name = user.Name;
            userFromDB.Gender = user.Gender;
            _context.SaveChanges();
        }
    }
}
