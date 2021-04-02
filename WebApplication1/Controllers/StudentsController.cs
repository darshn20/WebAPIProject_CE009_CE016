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
    public class StudentsController : ControllerBase
    {
        private IStudentRepo _repo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepo repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }
        //[Route("/Search")]
        [HttpGet("Search/{key}")]
        public ActionResult<IEnumerable<StudentReadDto>> SearchStudents(string key)
        {
            var StudentItems = _repo.SearchStudents(key);
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(StudentItems));
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var StudentModelFromDB = _repo.GetStudentById(id);
            if (StudentModelFromDB == null)
            {
                throw new ArgumentNullException(nameof(StudentModelFromDB));
            }
            _repo.DeleteStudent(StudentModelFromDB);
            _repo.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var StudentModelFromRepo = _repo.GetStudentById(id);
            if (StudentModelFromRepo == null)
            {
                return NotFound();
            }
            var StudentToPatch = _mapper.Map<StudentUpdateDto>(StudentModelFromRepo);
            patchDoc.ApplyTo(StudentToPatch, ModelState);
            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(StudentToPatch, StudentModelFromRepo);
            _repo.UpdateStudent(id, StudentModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<StudentReadDto> UpdateStudent(int id, StudentUpdateDto StudentUpdateDto)
        {
            var StudentModelFromDB = _repo.GetStudentById(id);
            if (StudentModelFromDB == null)
            {
                return NotFound();
            }
            _mapper.Map(StudentUpdateDto, StudentModelFromDB);
            _repo.UpdateStudent(id, StudentModelFromDB);
            _repo.SaveChanges();
            return NoContent();

            // return Ok(StudentModel);

        }
        [HttpPost]
        public ActionResult CreateStudent(StudentCreateDto StudentCreateDto)
        {
            var StudentModel = _mapper.Map<User>(StudentCreateDto);
            _repo.CreateStudent(StudentModel);
            _repo.SaveChanges();

            return NoContent();

            // return Ok(StudentModel);

        }
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var StudentItems = _repo.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(StudentItems));
        }
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var StudentItem = _repo.GetStudentById(id);
            if (StudentItem != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(StudentItem));
            }
            return NotFound();
        }
    }
}