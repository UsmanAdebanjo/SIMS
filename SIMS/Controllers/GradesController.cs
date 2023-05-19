//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SIMS.Models;
//using SIMS.Repositories;

//namespace SIMS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GradesController : ControllerBase
//    {
//        private readonly ISimsRepo<Grade> _simsRepo;
//        public GradesController(ISimsRepo<Grade> simsRepo)
//        {
//            _simsRepo = simsRepo;
//        }
//        [HttpPost]
//        public ActionResult AddGrade(Grade grade)
//        {
//            _simsRepo.Add(grade);
//            return Created("/api/GetAll", grade);
//        }
//        [HttpGet]
//        public ActionResult GetAll()
//        {
//            return Ok(_simsRepo.GetAll());
//        }

//        [HttpGet("id")]
//        public ActionResult Get(Guid id)
//        {
//            return Ok(_simsRepo.GetById(id));
//        }

//        [HttpPut("id")]
//        public ActionResult Update(Grade grade,Guid id)
//        {
//            _simsRepo.Update(grade,id);
//            return Ok();
//        }
//    }
//}
