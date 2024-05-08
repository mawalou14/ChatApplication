using BaseLibrary.Entities;

namespace BaseLibrary.DTO
{
    public class MessageDTO
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUserEntity ApplicationUser { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
