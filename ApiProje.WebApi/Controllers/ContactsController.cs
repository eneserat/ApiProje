using ApiProje.WebApi.Context;
using ApiProje.WebApi.DTOs.ContactDTOs;
using ApiProje.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                MapLocation = createContactDto.MapLocation,
                Adress = createContactDto.Adress,
                Phone = createContactDto.Phone,
                Email = createContactDto.Email,
                OpenHours = createContactDto.OpenHours
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim Bilgileri Sisteme Başarıyla Eklendi.");


        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound("İletişim Bilgileri Sistemde Bulunamadı.");
            }
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("İletişim Bilgileri Sistemden Başarıyla Silindi.");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound("İletişim Bilgileri Sistemde Bulunamadı.");
            }
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            Contact contact1=new Contact()
            {
                ContactID = contact.ContactID,
                MapLocation = contact.MapLocation,
                Adress = contact.Adress,
                Phone = contact.Phone,
                Email = contact.Email,
                OpenHours = contact.OpenHours
            };
            _context.Contacts.Update(contact1);
            _context.SaveChanges();
            return Ok("İletişim Bilgileri Sistemde Başarıyla Güncellendi.");
        }

    }

}
