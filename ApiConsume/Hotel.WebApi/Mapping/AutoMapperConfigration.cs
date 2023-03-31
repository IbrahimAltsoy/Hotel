using AutoMapper;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.DtoLayer.Dtos.ServiceDto;
using Hotel.EntitiyLayer.Concreate;

namespace Hotel.WebApi.Mapping
{
    public class AutoMapperConfigration:Profile
    {
        public AutoMapperConfigration()
        {
            CreateMap<AddRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();


        }
    }
}
