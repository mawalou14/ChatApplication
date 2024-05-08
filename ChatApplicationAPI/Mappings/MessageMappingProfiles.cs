using AutoMapper;
using BaseLibrary.DTO.messageDTOs;
using BaseLibrary.Entities;

namespace ChatApplicationAPI.Mappings
{
    public class MessageMappingProfiles : Profile
    {
        public MessageMappingProfiles()
        {
            CreateMap<MessageEntity, GetMessageDTO>().ReverseMap();
            CreateMap<AddMessageDTO, MessageEntity>().ReverseMap();
        }
    }
}
