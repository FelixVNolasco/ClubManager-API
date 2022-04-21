using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ManagerAPI.Dtos;
using Entities.Entities;
using Entities.Common;
using DataAccessManager.Repositories;
using DataAccessManager.Context;

namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {

        private readonly StudentRepository studentsRepository;

        private readonly AppDBContext context;

        public StudentController(IRepository<Student> studentsRepository, AppDBContext context)
        {
            this.studentsRepository = (StudentRepository)studentsRepository;
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<StudentDto> GetAllStudents()
        {
            var students = studentsRepository.GetAllStudents()
                        .Select(student => student.AsDto());
            return students;
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetStudent(int id)
        {
            var item = studentsRepository.GetStudent(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(CreateStudentDto createStudentDto)
        {
            var student = new Student
            {
                boleta = createStudentDto.boleta,
                firstName = createStudentDto.firstName,
                lastName = createStudentDto.lastName,
                email = createStudentDto.email,
                career = createStudentDto.career,
                school = createStudentDto.school,
                signedUp = createStudentDto.signedUp,
            };

            var existingStudentCount = context.students.Count(a => a.boleta == createStudentDto.boleta);
            if (existingStudentCount == 0)
            {
                studentsRepository.CreateStudent(student);
                return student.AsDto();
            } else
            {
                return NotFound();
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<StudentDto> UpdateStudent(int id, UpdateStudentDto updateStudentDto)
        {
            var existingItem = studentsRepository.GetStudent(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.boleta = updateStudentDto.boleta;
            existingItem.firstName = updateStudentDto.firstName;
            existingItem.lastName = updateStudentDto.lastName;
            existingItem.email = updateStudentDto.email;

            studentsRepository.UpdateStudent(existingItem);

            return existingItem.AsDto();
        }


        [HttpDelete("{id}")]
        public ActionResult<StudentDto> DeleteAsync(int id)
        {
            var student = studentsRepository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            studentsRepository.RemoveStudent(student.StudentId);

            return student.AsDto();
        }

    }
}
