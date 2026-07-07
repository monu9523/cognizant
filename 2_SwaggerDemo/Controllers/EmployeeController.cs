using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new()
        {
            new Employee{Id=1,Name="Ramesh",Department="HR",Salary=25000},
            new Employee{Id=2,Name="Suresh",Department="IT",Salary=40000},
            new Employee{Id=3,Name="Mahesh",Department="Finance",Salary=35000}
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Created("", employee);
        }
    }
}