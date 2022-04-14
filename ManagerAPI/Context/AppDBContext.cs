using ManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagerAPI.Context
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
    }
}
