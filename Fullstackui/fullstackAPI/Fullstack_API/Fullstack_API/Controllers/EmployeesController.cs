using Fullstack_API.Data;
using Fullstack_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fullstack_API.Controllers
{
    [ApiController] // Tells it is a API Controller
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullstackDbContext _fullstackDbContext;
        public EmployeesController(FullstackDbContext fullstackDbContext)
        {
            _fullstackDbContext = fullstackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullstackDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid(); // generates random id
            await _fullstackDbContext.Employees.AddAsync(employeeRequest); // add the employee
            await _fullstackDbContext.SaveChangesAsync(); // save the changes
            return Ok(employeeRequest);
        }
    }
}
