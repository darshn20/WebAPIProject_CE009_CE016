using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public class SqlTeacherRepo:ITeacherRepo
    {
        private readonly UserContext _context;
        public SqlTeacherRepo(UserContext context)
        {
            _context = context;
        }

        public IEnumerable<User> SearchTeachers(string key)
        {
            var teachers = _context.Users.Where(
                t => (t.Std.ToString().Contains(key) || t.Name.Contains(key) || t.Gender.Contains(key) || t.Subject.Contains(key) || t.Std.ToString().Contains(key)) && (t.Type == UserType.Teacher)).ToList();
            return teachers;
        }
        public void CreateTeacher(User teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            _context.Users.Add(teacher);
        }
        public void DeleteTeacher(User teacher)
        {
            if (teacher == null || teacher.Type!=UserType.Teacher)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            _context.Users.Remove(teacher);
        }

        public IEnumerable<User> GetAllTeachers()
        {
            var teachers = _context.Users.Where(x=>x.Type==UserType.Teacher).ToList();
            return teachers;
        }

        public User GetTeacherById(int id)
        {
            var teacher = _context.Users.FirstOrDefault(x => x.Id == id && x.Type==UserType.Teacher);
            return teacher;
        }

        public void PartialTeacherUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc)
        {

        }

        public void PartialUserUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTeacher(int id, User teacher)
        {
            var teacherFromDB = _context.Users.FirstOrDefault(x => x.Id == id && x.Type==UserType.Teacher);
            teacherFromDB.Name = teacher.Name;
            teacherFromDB.Gender = teacher.Gender;
            teacherFromDB.DOB = teacher.DOB;
            teacherFromDB.Type = UserType.Teacher;
            _context.SaveChanges();
        }
    }
}
