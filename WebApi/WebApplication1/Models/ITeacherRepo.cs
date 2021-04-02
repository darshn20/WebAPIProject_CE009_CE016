using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public interface ITeacherRepo
    {
        IEnumerable<User> SearchTeachers(string key);
        IEnumerable<User> GetAllTeachers();
        User GetTeacherById(int id);
        bool SaveChanges();
        void CreateTeacher(User User);
        void UpdateTeacher(int id, User User);
        void PartialUserUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc);
        void DeleteTeacher(User User);
    }
}
