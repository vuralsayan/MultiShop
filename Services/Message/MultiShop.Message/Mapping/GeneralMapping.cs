using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, CreateUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInBoxUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendBoxUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateUserMessageDto>().ReverseMap();
        }
    }
}
