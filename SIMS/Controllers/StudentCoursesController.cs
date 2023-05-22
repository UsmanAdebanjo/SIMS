using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.Dtos;
using SIMS.Models;
using SIMS.Repositories;
using System.Buffers.Text;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly ISimsRepo<StudentCourse> _simsRepoStudentCourse;
        private readonly ISimsRepo<Course> _simsRepoCourse;
        private readonly ISimsRepo<Grade> _simsRepoGrade;
        private readonly ISimsRepo<Student> _simsRepoStudent;
        private readonly IMapper _mapper;
        public StudentCoursesController(ISimsRepo<StudentCourse> simsRepoStudentCourse, 
                                        ISimsRepo<Course> simsRepoCourse,
                                        ISimsRepo<Grade> simsRepoGrade,
                                        ISimsRepo<Student> simsRepoStudent,
                                        IMapper mapper)
        {
            _simsRepoStudentCourse = simsRepoStudentCourse;
            _simsRepoCourse = simsRepoCourse;
            _simsRepoGrade = simsRepoGrade;
            _simsRepoStudent = simsRepoStudent;
            _mapper = mapper;    
        }

        [HttpPost]
        public ActionResult AddStudentCourses(StudentCourseDto studentCourseDto)
        {
            var studentCourse=_mapper.Map<StudentCourse>(studentCourseDto);
            _simsRepoStudentCourse.Add(studentCourse);
            return Created("api/StudentCourses", studentCourseDto);
        }

        [HttpGet]
        public ActionResult GetStudentCourses()
        {
            var studentCourseQuery = _simsRepoStudentCourse.GetAll().AsQueryable(); 
            var studentQuery = _simsRepoStudent.GetAll().AsQueryable(); 
            var courseQuery = _simsRepoCourse.GetAll().AsQueryable(); 
            var gradeQuery = _simsRepoGrade.GetAll().AsQueryable();

            var result = studentCourseQuery
                .Join(studentQuery,
                    q1 => q1.StudentId,
                    q2 => q2.Id,
                    (q1, q2) => new { StudentsCourseTable = q1, StudentsTable = q2 })
                .Join(courseQuery,
                    joined => joined.StudentsCourseTable.CourseId,
                    q3 => q3.Id,
                    (joined, q3) => new { joined.StudentsCourseTable, joined.StudentsTable, CoursesTable = q3 })
                .Join(gradeQuery,
                      joined => joined.StudentsCourseTable.GradeId,
                      q4 => q4.Id,
                      (joined, q4) => new { joined.StudentsCourseTable, joined.StudentsTable, joined.CoursesTable, GradesTable = q4 })

                .Where(joined => joined.StudentsCourseTable.StudentId == joined.StudentsTable.Id && joined.StudentsCourseTable.CourseId == joined.CoursesTable.Id && joined.StudentsCourseTable.GradeId == joined.GradesTable.Id)
                .Select(joined => new GetStudentCourseDto
                {
                    Id = joined.StudentsCourseTable.Id,
                    StudentId = joined.StudentsCourseTable.StudentId,
                    CourseId = joined.StudentsCourseTable.CourseId,
                    GradeId = joined.StudentsCourseTable.GradeId,
                    Student =
                    new StudentDto
                    {
                        FirstName = joined.StudentsTable.FirstName,
                        LastName = joined.StudentsTable.LastName,
                        Class = joined.StudentsTable.Class,
                        DateOfBirth = joined.StudentsTable.DateOfBirth
                    },
                    Course = new CourseDto
                    {
                        CourseCode=joined.CoursesTable.CourseCode,
                        CourseName=joined.CoursesTable.CourseName,
                        CourseTitle=joined.CoursesTable.CourseTitle
                    },
                    Grade = new GradeDto
                    {
                        Title=joined.GradesTable.Title,
                        Description=joined.GradesTable.Description
                    }

                });


            return Ok(result.ToList());



        }



        [HttpGet("id")]
        public ActionResult Get(Guid id)
        {
            return Ok(_simsRepoStudentCourse.GetById(id));

        }


    }
}
