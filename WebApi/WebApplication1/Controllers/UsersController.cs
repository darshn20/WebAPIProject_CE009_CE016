using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repo, IMapper mapper)
        {
            this._repo = repo;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromDB = _repo.GetUserById(id);
            if(userModelFromDB==null)
            {
                throw new ArgumentNullException(nameof(userModelFromDB));
            }
            _repo.DeleteUser(userModelFromDB);
            _repo.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id,JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userModelFromRepo = _repo.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(userToPatch, userModelFromRepo);
            _repo.UpdateUser(id,userModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<UserReadDto> UpdateUser(int id,UserUpdateDto userUpdateDto)
        {
            var userModelFromDB = _repo.GetUserById(id);
            if (userModelFromDB == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromDB);
            _repo.UpdateUser(id,userModelFromDB);
            _repo.SaveChanges();
            return NoContent();

        }
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repo.CreateUser(userModel);
            _repo.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new { Id = userModel.Id }, userReadDto);
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repo.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }
        [HttpGet("{id}",Name ="GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userItem = _repo.GetUserById(id);
            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }
            return NotFound();
        }
    }
}
