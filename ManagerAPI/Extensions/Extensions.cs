﻿using ManagerAPI.Dtos;
using ManagerAPI.Entities;

namespace ManagerAPI
{
    public static class Extensions
    {

        public static StudentDto AsDto(this Student student)
        {
            return new StudentDto(student.StudentId, student.firstName, student.lastName, student.email, student.career, student.school, student.signedUp);
        }


    }
}
