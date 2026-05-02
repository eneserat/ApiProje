using ApiProje.WebApi.DTOs.ContactDTOs;
using ApiProje.WebApi.DTOs.FeatureDTOs;
using ApiProje.WebApi.DTOs.MessageDTOs;
using ApiProje.WebApi.Entities;
using AutoMapper;

namespace ApiProje.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
                CreateMap<Feature,ResultFeatureDto>().ReverseMap();  
                CreateMap<Feature,CreateFeatureDto>().ReverseMap();  
                CreateMap<Feature,UpdateFeatureDto>().ReverseMap();  
                CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();
            
                

                CreateMap<Message,ResultMessageDto>().ReverseMap();
                CreateMap<Message,CreateMessageDto>().ReverseMap();
                CreateMap<Message,UpdateMessageDto>().ReverseMap();
                CreateMap<Message,GetByIdMessageDto>().ReverseMap();

        }
    }
}
