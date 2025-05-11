
using Microsoft.EntityFrameworkCore;

namespace Employee.DAL;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    
    public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();
}
