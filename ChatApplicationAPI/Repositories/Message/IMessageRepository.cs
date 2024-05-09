using BaseLibrary.Entities;

namespace ChatApplicationAPI.Repositories.Message
{
    public interface IMessageRepository
    {
        Task<List<MessageEntity>> GetAllAsync();
        Task<MessageEntity> AddMessage(MessageEntity message);

    }
}
