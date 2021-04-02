using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<User, StudentReadDto>();
            CreateMap<StudentCreateDto, User>();
            CreateMap<StudentUpdateDto, User>();
            CreateMap<User, StudentUpdateDto>();
        }
    }
}
