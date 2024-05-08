using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace ChatApplicationAPI.Repositories.ApplicationUser
{
    public class IApplicationUserImplementation : IApplicationUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public IApplicationUserImplementation(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ApplicationUserEntity> AddAsync(ApplicationUserEntity applicationUser)
        {
            await dbContext.ApplicationUsers.AddAsync(applicationUser);
            await dbContext.SaveChangesAsync();
            return applicationUser;
        }

        public async Task<List<ApplicationUserEntity>> GetAllAsync()
        {
           return await dbContext.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUserEntity> GetByIdAync(Guid id)
        {
            var user = await dbContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
