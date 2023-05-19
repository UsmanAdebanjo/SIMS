using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.Dtos;
using SIMS.Models;
using SIMS.Repositories;

namespace SIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly ISimsRepo<StudentCourse> _simsRepo;
        private readonly IMapper _mapper;
        public StudentCoursesController(ISimsRepo<StudentCourse> simsRepo, IMapper mapper)
        {
            _simsRepo = simsRepo;
            _mapper= mapper;    
        }

        [HttpPost]
        public ActionResult AddStudentCourses(StudentCourseDto studentCourseDto)
        {
            var studentCourse=_mapper.Map<StudentCourse>(studentCourseDto);
            _simsRepo.Add(studentCourse);
            return Created("/api/", studentCourse);
        }

        [HttpGet]
        public ActionResult Get()
        {
            _simsRepo.GetAll();
            return Ok();
        }

        [HttpGet("id")]
        public ActionResult Get(Guid id)
        {
            return Ok(_simsRepo.GetById(id));

        }
    }
}
