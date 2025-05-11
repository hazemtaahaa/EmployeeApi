

using Employee.DAL;

namespace Employee.BL;

public class EmployeeManager : IEmployeeManager
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //Get all Employees
    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var employees = await _unitOfWork.Employees.GetAllAsync();

        var result = employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            Position = e.Position
        }).ToList();

        return result;
    }

    //Get Employee by ID

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return null;
        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Position = employee.Position
        };
      
    }

    //Add New Employee

    public async Task<bool> CreateAsync(CreateEmployeeDto employeeDTO)
    {
        var employee = new EmployeeEntity

        {
            FirstName = employeeDTO.FirstName,
            LastName = employeeDTO.LastName,
            Email = employeeDTO.Email,
            Position = employeeDTO.Position
        };

        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    //Update Employee
    public async Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeDto employeeDTO)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return null;

        employee.FirstName = employeeDTO.FirstName;
        employee.LastName = employeeDTO.LastName;
        employee.Email = employeeDTO.Email;
        employee.Position = employeeDTO.Position;

        await _unitOfWork.CompleteAsync();
        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Position = employee.Position
        };
    }

    //Delete Employee
    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return false;

        _unitOfWork.Employees.Remove(employee);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}


