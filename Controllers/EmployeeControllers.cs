using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorveSoftApi.Data;
using SorveSoftApi.Models;
using SorveSoftApi.Utils;

namespace SorveSoftApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class EmployeeControllers : ControllerBase
    {
        private readonly SorveSoftDbContext _context;

        public EmployeeControllers(SorveSoftDbContext context)
        {
            _context = context;
        }

        [HttpGet("employees")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("employees/{id:int}")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost("employees")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PostAsync([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Created($"{employee.Id}", employee);
        }

        [HttpPut("employees/{id:int}")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Employee model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();

            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Phone = model.Phone;
            employee.Position = model.Position;
            employee.IsActive = model.IsActive;
            employee.UpdatedAt = DateTime.UtcNow;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete("employees/{id:int}")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
