

namespace Employee.BL;

public interface IEmployeeManager
{
  public Task<List<EmployeeDto>> GetAllAsync();
  public  Task<EmployeeDto?> GetByIdAsync(int id);
  public  Task<bool> CreateAsync(CreateEmployeeDto employeeDTO);
  public  Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeDto employeeDTO);
  public Task<bool> DeleteAsync(int id);
}
