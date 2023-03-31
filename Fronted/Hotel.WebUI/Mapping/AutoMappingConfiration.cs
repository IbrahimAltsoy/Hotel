using AutoMapper;
using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.ServiceDto;

namespace Hotel.WebUI.Mapping
{
    public class AutoMappingConfiration:Profile
    {
        public AutoMappingConfiration()
        {
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
        }
    }
}
