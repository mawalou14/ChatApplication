using AutoMapper;
using BaseLibrary.DTO;
using BaseLibrary.Entities;

namespace ChatApplicationAPI.Mappings
{
    public class MessageMappingProfiles : Profile
    {
        public MessageMappingProfiles()
        {
            CreateMap<MessageEntity, MessageDTO>().ReverseMap();
        }
    }
}
