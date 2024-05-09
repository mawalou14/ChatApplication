using BaseLibrary.Entities;

namespace BaseLibrary.DTO.messageDTOs
{
    public class AddMessageDTO
    {
        public string Message { get; set; }
        //public DateTime Date { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
