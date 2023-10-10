using AutoMapper;
using Hotel.DtoLayer.Dtos.AboutDto;
using Hotel.DtoLayer.Dtos.BookingDto;
using Hotel.DtoLayer.Dtos.ContactDto;
using Hotel.DtoLayer.Dtos.GuestDto;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.DtoLayer.Dtos.SenderMessage;
using Hotel.DtoLayer.Dtos.ServiceDto;
using Hotel.DtoLayer.Dtos.SubscribeDto;
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
            CreateMap<AddAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<AddSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<AddBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<AddContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<Create_Guest_Dto, Guest>().ReverseMap();
            CreateMap<Update_Guest_dto, Guest>().ReverseMap();
            CreateMap<AddSenderMessageDto, SenderMessage>().ReverseMap();
            CreateMap<UpdateSenderMessage, SenderMessage>().ReverseMap();
            


        }
    }
}
