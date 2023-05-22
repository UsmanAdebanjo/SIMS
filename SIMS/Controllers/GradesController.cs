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
    public class GradesController : ControllerBase
    {
        private readonly ISimsRepo<Grade> _simsRepo;
        private readonly IMapper _mapper;
        public GradesController(ISimsRepo<Grade> simsRepo, IMapper mapper)
        {
            _simsRepo = simsRepo;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult AddGrade(GradeDto gradeDto)
        {
           var grade= _mapper.Map<Grade>(gradeDto);
            _simsRepo.Add(grade);
            return Created("/api/GetAll", grade);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_simsRepo.GetAll());
        }

        [HttpGet("id")]
        public ActionResult Get(Guid id)
        {
            return Ok(_simsRepo.GetById(id));
        }

        [HttpPut("id")]
        public ActionResult Update(GradeDto gradeDto, Guid id)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            grade.Id = id;
            _simsRepo.Update(grade, id);
            return Ok();
        }
    }
}
