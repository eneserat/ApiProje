using ApiProje.WebApi.Context;
using ApiProje.WebApi.DTOs.NotificationDTOs;
using ApiProje.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;


        public NotificationsController(IMapper mapper, ApiContext context )
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Bildirim Sisteme Başarıyla Eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
            {
                return NotFound("Bildirim Sistemde Bulunamadı.");
            }
            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Bildirim Sistemden Başarıyla Silindi.");
        }
        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
            {
                return NotFound("Bildirim Sistemde Bulunamadı.");
            }
            return Ok(_mapper.Map<GetNotificationByIdDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return Ok("Bildirim Sistemde Başarıyla Güncellendi.");
        }
    }
}
