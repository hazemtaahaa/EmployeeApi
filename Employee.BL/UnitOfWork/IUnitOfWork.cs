namespace Employee.BL;

public interface IUnitOfWork 
{
    IEmployeesRepository Employees { get; }
    Task<int> CompleteAsync();
}
