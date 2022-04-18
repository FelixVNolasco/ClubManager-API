using ManagerEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAManager.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
