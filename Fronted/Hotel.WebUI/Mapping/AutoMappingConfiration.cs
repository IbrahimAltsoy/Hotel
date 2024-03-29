﻿using AutoMapper;
using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.AboutDto;
using Hotel.WebUI.Dtos.AppUserDto;
using Hotel.WebUI.Dtos.CategoryMessage;
using Hotel.WebUI.Dtos.ContactDto;
using Hotel.WebUI.Dtos.GuestDto;
using Hotel.WebUI.Dtos.LoginDto;
using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Dtos.SenderMessageDto;
using Hotel.WebUI.Dtos.ServiceDto;
using Hotel.WebUI.Dtos.StuffDto;
using Hotel.WebUI.Dtos.Subscribe;
using Hotel.WebUI.Dtos.TestimonialDto;
using Hotel.WebUI.Dtos.UINewsLetterStart;
using Hotel.WebUI.Dtos.WorkLocationDto;

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

            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();
            CreateMap<Login_User_Dto, AppUser>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultStuffDto, Stuff>().ReverseMap();
            CreateMap<Create_SubscribeDto, Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<DeleteSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<DeleteContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<DeleteAboutDto, About>().ReverseMap();
            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
            CreateMap<DeleteGuestDto, Guest>().ReverseMap();
            CreateMap<ResultGuestDto, Guest>().ReverseMap();
            CreateMap<MoveToArcihiveGuestDto, Guest>().ReverseMap();
            CreateMap<CreateSenderMessageDto, SenderMessage>().ReverseMap();
            CreateMap<UpdateSenderMessage, SenderMessage>().ReverseMap();
            CreateMap<ResultSenderMessage, SenderMessage>().ReverseMap();
            CreateMap<DeleteSenderMessageDto, SenderMessage>().ReverseMap();          
            CreateMap<CreateCategoryMessageDto, CategoryMessage>().ReverseMap();
            CreateMap<UpdateCategoryMessage, CategoryMessage>().ReverseMap();
            CreateMap<DeleteCategoryMessage, CategoryMessage>().ReverseMap();
            CreateMap<ResultCategoryMessage, CategoryMessage>().ReverseMap();
            CreateMap<ResultWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<CreateWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<UpdateWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<DeleteWorkLocationDto, WorkLocation>().ReverseMap();


            
            
        }
    }
}
