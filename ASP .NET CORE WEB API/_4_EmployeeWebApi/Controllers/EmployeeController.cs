using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    // Hardcoded in-memory list (static so it persists across requests in this demo)
    private static List<Employee> _employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Amit Sharma", Department = "IT", Salary = 55000 },
        new Employee { Id = 2, Name = "Priya Singh", Department = "HR", Salary = 48000 },
        new Employee { Id = 3, Name = "Rahul Verma", Department = "Finance", Salary = 62000 }
    };

    // GET: api/Employee
    [HttpGet]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(_employees);
    }

    // GET: api/Employee/1
    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == id);
        if (emp == null)
            return NotFound("Employee not found");

        return Ok(emp);
    }

    // PUT: api/Employee/1
    [HttpPut("{id}")]
    public ActionResult<Employee> Put(int id, [FromBody] Employee employeeInput)
    {
     
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

      
        var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        // Step 3: Update fields using data from request body
        existingEmployee.Name = employeeInput.Name;
        existingEmployee.Department = employeeInput.Department;
        existingEmployee.Salary = employeeInput.Salary;

        // Step 4: Filter list for updated employee & return it
        var updatedEmployee = _employees.Where(e => e.Id == id).FirstOrDefault();
        return Ok(updatedEmployee);
    }

    // POST: api/Employee
    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employeeInput)
    {
        employeeInput.Id = _employees.Max(e => e.Id) + 1;
        _employees.Add(employeeInput);
        return Ok(employeeInput);
    }

    // DELETE: api/Employee/1
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var emp = _employees.FirstOrDefault(e => e.Id == id);
        if (emp == null)
            return BadRequest("Invalid employee id");

        _employees.Remove(emp);
        return Ok($"Employee with id {id} deleted");
    }
}