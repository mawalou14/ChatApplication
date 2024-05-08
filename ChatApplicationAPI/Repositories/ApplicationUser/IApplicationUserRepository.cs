using BaseLibrary.Entities;

namespace ChatApplicationAPI.Repositories.ApplicationUser
{
    public interface IApplicationUserRepository
    {
        Task<List<ApplicationUserEntity>> GetAllAsync();
        Task<ApplicationUserEntity> AddAsync(ApplicationUserEntity applicationUser);
        Task<ApplicationUserEntity> GetByIdAync(Guid id);
    }
}
