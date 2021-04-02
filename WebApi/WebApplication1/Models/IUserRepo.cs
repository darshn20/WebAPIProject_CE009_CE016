using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool SaveChanges();
        void CreateUser(User user);
        void UpdateUser(int id,User user);
        void PartialUserUpdate(int id,JsonPatchDocument<UserUpdateDto> patchDoc);
        void DeleteUser(User user);

    }
}
