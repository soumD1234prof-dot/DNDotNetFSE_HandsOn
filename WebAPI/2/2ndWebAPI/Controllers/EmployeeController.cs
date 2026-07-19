using _2ndWebAPI;
using Microsoft.AspNetCore.Mvc;

namespace _2ndWebAPI.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> Employees = new()
        {
            new Employee { Id = 1, Name = "Asha Rao", Department = "Engineering" },
            new Employee { Id = 2, Name = "Vikram Shah", Department = "Sales" }
        };

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return Employees;
        }
    }
}