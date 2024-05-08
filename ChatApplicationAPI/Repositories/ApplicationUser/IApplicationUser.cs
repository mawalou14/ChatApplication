using BaseLibrary.Entities;

namespace ChatApplicationAPI.Repositories.ApplicationUser
{
    public interface IApplicationUser
    {
        Task<List<ApplicationUserEntity>> GetAllAsync();
        Task<ApplicationUserEntity> AddAsync(ApplicationUserEntity applicationUser);
    }
}
