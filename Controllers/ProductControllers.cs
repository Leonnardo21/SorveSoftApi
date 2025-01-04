using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorveSoftApi.Data;
using SorveSoftApi.Models;
using SorveSoftApi.Utils;

namespace SorveSoftApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductControllers : ControllerBase
    {
        private readonly SorveSoftDbContext _context;
        public ProductControllers(SorveSoftDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("products/{id:int}")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("products")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PostAsync([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Created($"{product.Id}", product);
        }

        [HttpPut("products/{id:int}")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Description = model.Description;
            product.Category = model.Category;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.ImageUrl = model.ImageUrl;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("products/{id:int}")]
        [TypeFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product == null)
                    return NotFound();

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return NoContent();
        }
    }
}