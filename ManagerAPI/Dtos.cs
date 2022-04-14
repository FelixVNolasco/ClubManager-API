﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Dtos
{
    public record StudentDto(Guid StudentId, string firstName, string lastName, string email, string career, string school, bool signedUp);

    public record CreateStudentDto([Required] string firstName, string lastName, string email, string career, string school, bool signedUp);

    public record UpdateStudentDto(string firstName, string lastName, string email);
}
