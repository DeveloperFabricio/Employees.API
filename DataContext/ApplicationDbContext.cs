using Employees.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
