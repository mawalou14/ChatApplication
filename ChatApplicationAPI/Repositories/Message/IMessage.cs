using BaseLibrary.Entities;

namespace ChatApplicationAPI.Repositories.Message
{
    public interface IMessage
    {
        Task<List<MessageEntity>> GetAllAsync();
        Task<MessageEntity> AddMessage(MessageEntity message);
    }
}
