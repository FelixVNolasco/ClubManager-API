using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Dtos
{
    public record StudentDto(int StudentId, string boleta, string firstName, string lastName, string email, string career, string school, bool signedUp);

    public record CreateStudentDto([Required] string firstName, string boleta, string lastName, string email, string career, string school, bool signedUp);

    public record UpdateStudentDto([Required] string firstName, string boleta, string lastName, string email);
}
