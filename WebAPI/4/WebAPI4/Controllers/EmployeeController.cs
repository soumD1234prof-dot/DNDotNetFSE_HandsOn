using Microsoft.AspNetCore.Mvc;

namespace WebAPI4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> _employees = new()
        {
            new Employee { Id = 1, Name = "Asha Rao", Salary = 75000, Permanent = true },
            new Employee { Id = 2, Name = "Vikram Shah", Salary = 60000, Permanent = false },
            new Employee { Id = 3, Name = "Neha Iyer", Salary = 82000, Permanent = true }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employees);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)
        {
            // Check 1: id <= 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Check 2: id > 0 but not found in the hardcoded list
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Valid id: update the hardcoded list using JSON body data
            existing.Name = updatedEmployee.Name;
            existing.Salary = updatedEmployee.Salary;
            existing.Permanent = updatedEmployee.Permanent;

            // Filter and return the updated employee
            var result = _employees.Where(e => e.Id == id).ToList();
            return Ok(result);
        }
    }
}
