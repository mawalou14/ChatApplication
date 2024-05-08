using AutoMapper;
using BaseLibrary.DTO.ApplicationUserDTOs;
using BaseLibrary.Entities;

namespace ChatApplicationAPI.Mappings
{
    public class ApplicationUserMappingProfiles : Profile
    {
        public ApplicationUserMappingProfiles()
        {
            CreateMap<ApplicationUserEntity, GetApplicationUsersDTO>().ReverseMap();
            CreateMap<AddApplicationUsersDTO, ApplicationUserEntity>().ReverseMap();
        }
    }
}
