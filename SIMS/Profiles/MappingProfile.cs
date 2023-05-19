using AutoMapper;
using SIMS.Dtos;
using SIMS.Models;

namespace SIMS.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
