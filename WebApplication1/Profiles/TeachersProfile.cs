using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class TeachersProfile : Profile
    {
        public TeachersProfile()
        {
            CreateMap<User, TeacherReadDto>();
            CreateMap<TeacherCreateDto, User>();
            CreateMap<TeacherUpdateDto, User>();
            CreateMap<User, TeacherUpdateDto>();
        }
    }
}
