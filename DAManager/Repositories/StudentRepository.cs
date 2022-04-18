using System.Collections.Generic;
using DAManager.Context;
using ManagerEntities.Common;
using ManagerEntities.Entities;

namespace DAManager.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDBContext context;

        public StudentRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Student CreateStudent(Student student)
        {
            context.students.Add(student);
            context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.students;
        }

        public Student GetStudent(int id)
        {
            return context.students.Find(id);
        }

        public Student RemoveStudent(int id)
        {
            Student student = context.students.Find(id);
            if (student != null)
            {
                context.students.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public Student UpdateStudent(Student studentChanges)
        {
            var student = context.students.Attach(studentChanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;
        }
    }
}
