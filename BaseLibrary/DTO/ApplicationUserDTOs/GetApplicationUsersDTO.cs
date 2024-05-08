using BaseLibrary.Entities;

namespace BaseLibrary.DTO.ApplicationUserDTOs
{
    public class GetApplicationUsersDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
