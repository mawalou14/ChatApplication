namespace BaseLibrary.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUserEntity ApplicationUser { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
