using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI3.Filters;

namespace WebAPI3.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        // Constructor: create a few records
        public EmployeeController()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Asha Rao",
                    Salary = 75000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "Engineering" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "SQL" } },
                    DateOfBirth = new DateTime(1992, 4, 15)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Vikram Shah",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "Sales" },
                    Skills = new List<Skill> { new Skill { Id = 3, Name = "Negotiation" } },
                    DateOfBirth = new DateTime(1988, 11, 2)
                }
            };
        }

        // Private method that returns the standard list
        private List<Employee> GetStandardEmployeeList()
        {
            return _employees;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(GetStandardEmployeeList());
            //throw new Exception("Test exception for CustomExceptionFilter");
            //return Ok(GetStandardEmployeeList());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();
            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            return Ok(existing);
        }
    }
}