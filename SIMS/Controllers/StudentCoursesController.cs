//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SIMS.Models;
//using SIMS.Repositories;

//namespace SIMS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentCoursesController : ControllerBase
//    {
//        private readonly ISimsRepo<StudentCourse> _simsRepo;
//        public StudentCoursesController(ISimsRepo<StudentCourse> simsRepo)
//        {
//            _simsRepo=simsRepo;
//        }

//        [HttpPost]
//        public ActionResult AddStudentCourses(StudentCourse studentCourse)
//        {
//            _simsRepo.Add(studentCourse);
//            return Created("/api/", studentCourse);
//        }

//        [HttpGet]
//        public ActionResult Get()
//        {
//            _simsRepo.GetAll();
//            return Ok();
//        }

//        [HttpGet("id")]
//        public ActionResult Get(Guid id)
//        {
//          return Ok(_simsRepo.GetById(id));
           
//        }
//    }
//}
