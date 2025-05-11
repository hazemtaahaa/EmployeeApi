using Employee.DAL;



namespace Employee.BL;

public class EmployeesRepository : Repository<EmployeeEntity>,IEmployeesRepository
{
    private readonly AppDbContext _context;
    public EmployeesRepository(AppDbContext context): base(context)
    {
        _context = context;
    }
   
}
