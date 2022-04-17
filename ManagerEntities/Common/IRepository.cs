
using System.Collections.Generic;
using ManagerEntities.Entities;

namespace ManagerEntities.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Student CreateStudent(T entity);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        Student RemoveStudent(int id);
        Student UpdateStudent(T entity);
    }
}
