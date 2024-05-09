using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace ChatApplicationAPI.Repositories.Message
{
    public class IMessageImplementation : IMessageRepository
    {
        private readonly ApplicationDbContext dbContext;

        public IMessageImplementation(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<MessageEntity> AddMessage(MessageEntity message)
        {
           await dbContext.Messages.AddAsync(message);
            await dbContext.SaveChangesAsync();
            return message;
        }

        public async Task<List<MessageEntity>> GetAllAsync()
        {
            return await dbContext.Messages.Include(x => x.ApplicationUser).ToListAsync();
        }

        public async Task<MessageEntity> GetByIdAsync(Guid id)
        {
            var foundMessage = await dbContext.Messages.FirstOrDefaultAsync(x => x.Id == id);
            if (foundMessage == null)
            {
                return null;
            } 
            return foundMessage;
        }
    }
}
