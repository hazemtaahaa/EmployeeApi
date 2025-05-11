
using Employee.BL;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeManager _manager;

    public EmployeesController(IEmployeeManager manager)
    {
        _manager = manager;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _manager.GetAllAsync();

        if (result == null)
        {
            return BadRequest(new GeneralResult(400, "No Employee Found!"));
        }
        return Ok(new GeneralResult<IReadOnlyList<EmployeeDto>>(200, result, "Employees get Succsfully"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _manager.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound(new GeneralResult(404, "Employee Not Found!"));
        }
        return Ok(new GeneralResult<EmployeeDto>(200, result, "Employee get Succsfully"));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var result = await _manager.CreateAsync(dto);
        if (result == false)
        {
            return BadRequest(new GeneralResult(400, "Employee Not Created!"));
        }
        return
            Ok(new GeneralResult(200, "Employee Added Succsfully"));
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateEmployeeDto dto)
    {
        var result = await _manager.UpdateAsync(id, dto);
        if (result == null)
        {
            return NotFound(new GeneralResult(404, "Employee Not Found!"));
        }
        return Ok(new GeneralResult<EmployeeDto>(200, result, "Employee Updated Succsfully"));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) 
    {
        var result = await _manager.DeleteAsync(id);
        if (result == false)
        {
            return NotFound(new GeneralResult(404, "Employee Not Found!"));
        }
        return Ok(new GeneralResult(200, "Employee Deleted Succsfully"));

    }
}
