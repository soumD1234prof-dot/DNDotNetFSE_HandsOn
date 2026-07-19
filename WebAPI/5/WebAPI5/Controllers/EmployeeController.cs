using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI5;

namespace WebAPI5.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    [Authorize(Roles = "Admin,POC")]
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
    }
}
