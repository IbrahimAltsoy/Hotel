using AutoMapper;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.EntitiyLayer.Concreate;

namespace Hotel.WebApi.Mapping
{
    public class AutoMapperConfigration:Profile
    {
        public AutoMapperConfigration()
        {
            CreateMap<AddRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
