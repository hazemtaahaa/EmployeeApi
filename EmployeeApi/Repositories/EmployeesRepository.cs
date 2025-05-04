namespace EmployeeApi;

public class EmployeesRepository : Repository<Employee>,IEmployeesRepository
{
    private readonly AppDbContext _context;
    public EmployeesRepository(AppDbContext context): base(context)
    {
        _context = context;
    }
   
}
