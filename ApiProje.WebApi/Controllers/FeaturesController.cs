using ApiProje.WebApi.Context;
using ApiProje.WebApi.DTOs.FeatureDTOs;
using ApiProje.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;


        public FeaturesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Özellik Sisteme Başarıyla Eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
            {
                return NotFound("Özellik Sistemde Bulunamadı.");
            }
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Özellik Sistemden Başarıyla Silindi.");
        }
        [HttpGet("GetFeature")] 
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
            {
                return NotFound("Özellik Sistemde Bulunamadı.");
            }
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Özellik Sistemde Başarıyla Güncellendi.");
        }
    }
}
