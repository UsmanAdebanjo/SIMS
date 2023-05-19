using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIMS.Dtos;
using SIMS.Models;
using SIMS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ISimsRepo<Course> _simsRepo;
        private readonly IMapper _mapper;
        public CoursesController(ISimsRepo<Course> simsRepo, IMapper mapper)
        {
            _simsRepo = simsRepo;
            _mapper = mapper;   
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_simsRepo.GetAll());

        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return Ok(_simsRepo.GetById(id));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult Post(CourseDto courseDto)
        {
            var course= _mapper.Map<Course>(courseDto); 

            _simsRepo.Add(course);
            return Created("/api/GetAll", course);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _simsRepo.Update(course, id);
            return Ok();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _simsRepo.Delete(id);
            return NoContent();
        }

    }
}
