using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ManagerAPI.Entities;

namespace ManagerAPI.Common
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
