using Microsoft.EntityFrameworkCore;

namespace EmployeeInfoSystem.Model
{
    public class EmployeeContext : DbContext

    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) {
        
        }
      
        public DbSet<TblEmployee> TblEmployee  { get; set; }
        public DbSet<TblDepartment> TblDepartment { get; set; }
    }
}
