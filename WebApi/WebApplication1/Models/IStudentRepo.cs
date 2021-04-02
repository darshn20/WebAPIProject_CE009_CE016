using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public interface IStudentRepo
    {
        IEnumerable<User> SearchStudents(string key);
        IEnumerable<User> GetAllStudents();
        User GetStudentById(int id);
        bool SaveChanges();
        void CreateStudent(User User);
        void UpdateStudent(int id, User User);
        void PartialUserUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc);
        void DeleteStudent(User User);
    }
}
