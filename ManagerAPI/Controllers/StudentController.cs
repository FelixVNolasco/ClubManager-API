﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerAPI.Dtos;
using ManagerAPI.Entities;
using ManagerAPI.Common;
using ManagerAPI.Repositories;


//FIX: System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Guid'.
namespace ManagerAPI.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {

        private readonly StudentRepository studentsRepository;

        public StudentController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = (StudentRepository)studentsRepository;
        }
        
        [HttpGet]
        public IEnumerable<StudentDto> GetAllStudents()
        {
            var students = studentsRepository.GetAllStudents()
                        .Select(student => student.AsDto());
            return students;
        }

        [HttpGet("{id}")]
        public StudentDto GetStudent(int id)
        {
            var item =  studentsRepository.GetStudent(id);

            //if (item == null)
            //{
            //    return item;
            //}

            return item.AsDto();
        }

        [HttpPost]
        public StudentDto CreateStudent(CreateStudentDto createStudentDto)
        {
            var student = new Student
            {
                firstName = createStudentDto.firstName,
                lastName = createStudentDto.lastName,
                email = createStudentDto.email,
                career = createStudentDto.career,
                school = createStudentDto.school,
                signedUp = createStudentDto.signedUp,
            };

            studentsRepository.CreateStudent(student);
            return student.AsDto();
        }

        [HttpPut("{id}")]
        public StudentDto UpdateStudent(int id, UpdateStudentDto updateStudentDto)
        {
            var existingItem = studentsRepository.GetStudent(id);

            //if (existingItem == null)
            //{
            //    return NotFound();
            //}

            existingItem.firstName= updateStudentDto.firstName;
            existingItem.lastName= updateStudentDto.lastName;
            existingItem.email= updateStudentDto.email;

            studentsRepository.UpdateStudent(existingItem);

            return existingItem.AsDto();
        }


        [HttpDelete("{id}")]
        public Student DeleteAsync(int id)
        {
            var student = studentsRepository.GetStudent(id);

            //if (item == null)
            //{
            //    return NotFound();
            //}

            studentsRepository.RemoveStudent(student.StudentId);

            return student;
        }

    }
}
