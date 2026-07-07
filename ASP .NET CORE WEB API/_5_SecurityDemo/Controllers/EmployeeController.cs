using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityDemo.Models;

namespace SecurityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Rohit",
                    Department = "HR"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Priya",
                    Department = "IT"
                }
            };

            return Ok(employees);
        }
    }
}