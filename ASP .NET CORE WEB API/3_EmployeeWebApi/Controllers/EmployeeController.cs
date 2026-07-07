using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeWebApiDemo.Models;
using EmployeeWebApiDemo.Filters;

namespace EmployeeWebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]                          // applies auth check to every action in this controller
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        // Constructor creates a few sample records
        public EmployeeController()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1, Name = "Ravi Kumar", Salary = 55000, Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "SQL" } },
                    DateOfBirth = new System.DateTime(1990, 5, 12)
                },
                new Employee
                {
                    Id = 2, Name = "Anita Sharma", Salary = 62000, Permanent = false,
                    Department = new Department { Id = 2, Name = "HR" },
                    Skills = new List<Skill> { new Skill { Id = 3, Name = "Communication" } },
                    DateOfBirth = new System.DateTime(1988, 8, 23)
                },
                new Employee
                {
                    Id = 3, Name = "Vikram Singh", Salary = 48000, Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill> { new Skill { Id = 4, Name = "Angular" }, new Skill { Id = 5, Name = "REST API" } },
                    DateOfBirth = new System.DateTime(1992, 3, 15)
                }
            };
        }

        // Private method returning the seeded list
        private List<Employee> GetStandardEmployeeList()
        {
            return _employees;
        }

        // GET api/employee
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> Get()
        {
            var employees = GetStandardEmployeeList();
            return Ok(employees);
        }

        // GET api/employee/throwerror  -> used to test CustomExceptionFilter
        [HttpGet("throwerror")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Employee> GetWithError()
        {
            throw new System.Exception("Something went wrong while fetching employee data.");
        }

        // POST api/employee
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required.");

            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT api/employee/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            existing.Permanent = employee.Permanent;
            existing.Department = employee.Department;
            existing.Skills = employee.Skills;
            existing.DateOfBirth = employee.DateOfBirth;

            return NoContent();
        }
    }
}