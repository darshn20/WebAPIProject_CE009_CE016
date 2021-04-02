using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public class SqlStudentRepo:IStudentRepo
    {
        private readonly UserContext _context;
        public SqlStudentRepo(UserContext context)
        {
            _context = context;
        }

        public void CreateStudent(User student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Users.Add(student);
        }
        public void DeleteStudent(User student)
        {
            if (student == null || student.Type!=UserType.Student)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Users.Remove(student);
        }

        public IEnumerable<User> GetAllStudents()
        {
            var students = _context.Users.Where(x=>x.Type==UserType.Student).ToList();
            return students;
        }

        public User GetStudentById(int id)
        {
            var student = _context.Users.FirstOrDefault(x => x.Id == id && x.Type==UserType.Student);
            return student;
        }

        public void PartialUserUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<User> SearchStudents(string key)
        {
            var students= _context.Users.Where(
                t =>(t.Std.ToString().Contains(key) || t.Name.Contains(key) || t.Gender.Contains(key) || t.Subject.Contains(key) || t.Std.ToString().Contains(key))&&(t.Type==UserType.Student)).ToList();
            return students;
        }

        public void UpdateStudent(int id, User student)
        {
            var studentFromDB = _context.Users.FirstOrDefault(x => x.Id == id && x.Type==UserType.Student);
            studentFromDB.Name = student.Name;
            studentFromDB.Gender = student.Gender;
            studentFromDB.DOB = student.DOB;
            studentFromDB.Type = UserType.Student;
            studentFromDB.Std = student.Std;
            _context.SaveChanges();
        }
    }
}
