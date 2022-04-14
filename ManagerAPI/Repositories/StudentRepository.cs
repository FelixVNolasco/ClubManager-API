using ManagerAPI.Common;
using ManagerAPI.Context;
using ManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ManagerAPI.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDBContext context;

        public StudentRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Task CreateAsync(Student student)
        {
            context.students.Add(student);
            context.SaveChanges();
            //return student;
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Student>> GetAllSync()
        {
            //return context.students;
            throw new NotImplementedException();
        }

        public Task<Student> GetAsync(Guid id)
        {
            //return context.students.FindAsync(id);
            throw new NotImplementedException();
        }


        public Task RemoveAsync(Guid id)
        {
            Student student = context.students.Find(id);
            if (student == null)
            {
                context.students.Remove(student);
                context.SaveChanges();
            }
            return Task.CompletedTask;
            //return student;
        }

        public Task UpdateAsync(Student studentChanges)
        {

            var student = context.students.Attach(studentChanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            //return studentChanges;
            throw new NotImplementedException();
        }
    }
}
