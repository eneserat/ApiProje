using ApiProje.WebApi.Context;
using ApiProje.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values= _context.Testimonials.ToList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Testimonial başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial (int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null)
            {
                return NotFound("Testimonial bulunamadı.");
            }
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Testimonial başarıyla silindi.");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null)
            {
                return NotFound("Testimonial bulunamadı.");
            }
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Testimonial Başarıyla Güncellendi.");
        }
    }
}
