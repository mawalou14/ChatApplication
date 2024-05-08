using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace ChatApplicationAPI.Repositories.Message
{
    public class IMessageImplementation : IMessage
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
            return await dbContext.Messages.ToListAsync();
        }
    }
}
