namespace EmployeeApi;

public interface IUnitOfWork 
{
    IEmployeesRepository Employees { get; }
    Task<int> CompleteAsync();
}
