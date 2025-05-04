using EmployeeApi.Models;

namespace EmployeeApi;

public class EmployeeManager
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //Get all Employees
    public async Task<GeneralResponse<List<EmployeeDto>>> GetAllAsync()
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

        return new GeneralResponse<List<EmployeeDto>>("Employees fetched", result);
    }

    //Get Employee by ID
    public async Task<GeneralResponse<EmployeeDto>> GetByIdAsync(int id)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return new GeneralResponse<EmployeeDto>("Not found", null, false, "Invalid ID");

        return new GeneralResponse<EmployeeDto>("Employee found", new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Position = employee.Position
        });
    }



    //Add New Employee
    public async Task<GeneralResponse<EmployeeDto>> CreateAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Position = dto.Position
        };

        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.CompleteAsync();

        return new GeneralResponse<EmployeeDto>("Employee created", new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Position = employee.Position
        });
    }


    //Update Employee
    public async Task<GeneralResponse<string>> UpdateAsync(int id, UpdateEmployeeDto dto)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return new GeneralResponse<string>("Not found", null, false, "Invalid ID");

        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Email = dto.Email;
        employee.Position = dto.Position;

        await _unitOfWork.CompleteAsync();
        return new GeneralResponse<string>("Employee updated");
    }

    //Delete Employee
    public async Task<GeneralResponse<string>> DeleteAsync(int id)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return new GeneralResponse<string>("Not found", null, false, "Invalid ID");

        _unitOfWork.Employees.Remove(employee);
        await _unitOfWork.CompleteAsync();

        return new GeneralResponse<string>("Employee deleted");
    }
}


