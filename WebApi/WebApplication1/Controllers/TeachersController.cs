using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeacherRepo _repo;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepo repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }

        [HttpGet("Search/{key}")]
        public ActionResult<IEnumerable<TeacherReadDto>> SearchStudents(string key)
        {
            var StudentItems = _repo.SearchTeachers(key);
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(StudentItems));
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTeacher(int id)
        {
            var TeacherModelFromDB = _repo.GetTeacherById(id);
            if (TeacherModelFromDB == null)
            {
                throw new ArgumentNullException(nameof(TeacherModelFromDB));
            }
            _repo.DeleteTeacher(TeacherModelFromDB);
            _repo.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PartialTeacherUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc)
        {
            var TeacherModelFromRepo = _repo.GetTeacherById(id);
            if (TeacherModelFromRepo == null)
            {
                return NotFound();
            }
            var TeacherToPatch = _mapper.Map<TeacherUpdateDto>(TeacherModelFromRepo);
            patchDoc.ApplyTo(TeacherToPatch, ModelState);
            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(TeacherToPatch, TeacherModelFromRepo);
            _repo.UpdateTeacher(id, TeacherModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateTeacher(int id, TeacherUpdateDto TeacherUpdateDto)
        {
            var TeacherModelFromDB = _repo.GetTeacherById(id);
            if (TeacherModelFromDB == null)
            {
                return NotFound();
            }
            _mapper.Map(TeacherUpdateDto, TeacherModelFromDB);
            _repo.UpdateTeacher(id, TeacherModelFromDB);
            _repo.SaveChanges();
            return NoContent();

            // return Ok(TeacherModel);

        }
        [HttpPost]
        public ActionResult CreateTeacher(TeacherCreateDto TeacherCreateDto)
        {
            var TeacherModel = _mapper.Map<User>(TeacherCreateDto);
            _repo.CreateTeacher(TeacherModel);
            _repo.SaveChanges();

            return NoContent();

        }
        [HttpGet]
        public ActionResult<IEnumerable<TeacherReadDto>> GetAllTeachers()
        {
            var TeacherItems = _repo.GetAllTeachers();
            return Ok(_mapper.Map<IEnumerable<TeacherReadDto>>(TeacherItems));
        }
        [HttpGet("{id}", Name = "GetTeacherById")]
        public ActionResult<TeacherReadDto> GetTeacherById(int id)
        {
            var TeacherItem = _repo.GetTeacherById(id);
            if (TeacherItem != null)
            {
                return Ok(_mapper.Map<TeacherReadDto>(TeacherItem));
            }
            return NotFound();
        }
    }
}