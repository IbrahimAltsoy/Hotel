using AutoMapper;
using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.AppUserDto;
using Hotel.WebUI.Dtos.LoginDto;
using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Dtos.ServiceDto;
using Hotel.WebUI.Dtos.StuffDto;
using Hotel.WebUI.Dtos.Subscribe;
using Hotel.WebUI.Dtos.TestimonialDto;
using Hotel.WebUI.Dtos.UINewsLetterStart;

namespace Hotel.WebUI.Mapping
{
    public class AutoMappingConfiration:Profile
    {
        public AutoMappingConfiration()
        {
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<DeleteServiceDto, Service>().ReverseMap();
            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<MoveToArcihiveRoomDto, Room>().ReverseMap();
            CreateMap<Create_AppUser_Dto, AppUser>().ReverseMap();
            CreateMap<Login_User_Dto, AppUser>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultStuffDto, Stuff>().ReverseMap();
            CreateMap<Create_SubscribeDto, Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<DeleteSubscribeDto, Subscribe>().ReverseMap();
        }
    }
}
