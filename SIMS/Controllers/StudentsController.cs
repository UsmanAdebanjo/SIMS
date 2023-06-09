﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.Dtos;
using SIMS.Models;
using SIMS.Repositories;

namespace SIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ISimsRepo<Student> _simsRepo;
        private readonly IMapper _mapper;   
        public StudentsController(ISimsRepo<Student> simsRepo, IMapper mapper)
        {
            _simsRepo = simsRepo;
            _mapper = mapper;
        }
        
        [HttpGet("id")]
        public ActionResult GetResult(Guid id)
        {
            return Ok(_simsRepo.GetById(id));
        }

        [HttpGet]
        public ActionResult GetResults()
        {
            var result= _simsRepo.GetAll();
            return Ok(result); 
        }

        [HttpGet]
        [Route("api/Students/PagingStudents/{pageNumber=1}/{pageSize=3}")]
        public ActionResult PagingStudents(int pageNumber, int pageSize)
        {

            var studentsInDb=_simsRepo.GetAll().OrderBy(s => s.LastName);
            var pages = studentsInDb.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return Ok(pages);

        }


        [HttpPost]
        public ActionResult AddStudent(StudentDto studentDto)
        {
           var student= _mapper.Map<Student>(studentDto); 
           

            _simsRepo.Add(student);
            Console.WriteLine("Student " + student.FirstName + " created at " + DateTime.Now);
            return Created("",student);
           
        }

        [HttpPut("id")]
        public ActionResult UpdateStudent(StudentDto studentDto, Guid id)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.Id=id;
            var result = _simsRepo.Update(student, id);
            if (result == true)
            {
                Console.WriteLine("Student " + student.FirstName + " updated at " + DateTime.Now);
                return Ok(); 
            }
            else { return BadRequest("Something went wrong"); }

        }

        [HttpDelete("id")]
        public ActionResult DeleteStudent(Guid id)
        {
            _simsRepo.Delete(id);
           var i= _simsRepo.SaveChanges();
            _simsRepo.Dispose();
            if (i == 1)
            {
                return NoContent();
            }
            else { return NotFound(); }

        }
        
        
    }
}
