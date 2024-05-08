using AutoMapper;
using BaseLibrary.DTO;
using BaseLibrary.Entities;

namespace ChatApplicationAPI.Mappings
{
    public class ApplicationUserMappingProfiles : Profile
    {
        public ApplicationUserMappingProfiles()
        {
            CreateMap<ApplicationUserEntity, ApplicationUserDTO>().ReverseMap();
        }
    }
}
