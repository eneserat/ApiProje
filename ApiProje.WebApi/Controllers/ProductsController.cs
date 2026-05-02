using ApiProje.WebApi.Context;
using ApiProje.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;

        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _context.Products.ToListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok("Ürün Başarıyla Eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _context.Products.FindAsync(id);

            if (value == null)
            {
                return NotFound("Ürün Sistemde Bulunamadı.");
            }

            _context.Products.Remove(value);
            await _context.SaveChangesAsync();

            return Ok("Ürün Sistemden Başarıyla Silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _context.Products.FindAsync(id);

            if (value == null)
            {
                return NotFound("Ürün Sistemde Bulunamadı.");
            }

            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var value = await _context.Products.FindAsync(product.ProductID);

            if (value == null)
            {
                return NotFound("Ürün Sistemde Bulunamadı.");
            }

            value.ProductName = product.ProductName;
            value.Price = product.Price;

            await _context.SaveChangesAsync();

            return Ok("Ürün Başarıyla Güncellendi.");
        }
    }
}