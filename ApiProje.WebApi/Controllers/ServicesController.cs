using ApiProje.WebApi.Context;
using ApiProje.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext? _context;
        public ServicesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services
                .Select(x => new
                {
                    x.ServiceID,
                    x.Title,
                    x.Description,
                    x.IconUrl
                })
                .ToList();

            return Ok(values);
        }
            [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Servis başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            {
                return NotFound("Servis bulunamadı.");
            }
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Servis başarıyla silindi.");
        }
        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            {
                return NotFound("Servis bulunamadı.");
            }
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis Başarıyla Güncellendi.");

        }
    }
}

