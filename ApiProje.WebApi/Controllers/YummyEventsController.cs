using ApiProje.WebApi.Context;
using ApiProje.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext? _context;
        public YummyEventsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult YummyEventyList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateYummyEventy(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Add(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteYummyEventy(int id)
        {
            var value = _context.YummyEvents.Find(id);
            if (value == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }
            _context.YummyEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla silindi.");
        }
        [HttpGet("GetYummyEventy")]
        public IActionResult GetYummyEventy(int id)
        {
            var value = _context.YummyEvents.Find(id);
            if (value == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateYummyEventy(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Update(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla güncellendi.");

        }
    }
}
