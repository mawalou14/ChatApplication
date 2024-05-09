using AutoMapper;
using BaseLibrary.DTO.messageDTOs;
using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
using ChatApplicationAPI.Repositories.ApplicationUser;
using ChatApplicationAPI.Repositories.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IMessageRepository messageRepository;
        private readonly IApplicationUserRepository userRepository;

        public MessageController(ApplicationDbContext dbContext, IMapper mapper, IMessageRepository messageRepository, IApplicationUserRepository userRepository )
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var messages = await messageRepository.GetAllAsync();
            var getMessageDto = mapper.Map<List<GetMessageDTO>>(messages);
            return Ok(getMessageDto);
        }

        [HttpGet("{id:guid}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var foundMessage = await messageRepository.GetByIdAsync(id);
            if (foundMessage == null)
            {
                return NotFound();
            }
            return Ok(foundMessage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddMessageDTO message)
        {
            var userId = message.ApplicationUserId;
            var user = await userRepository.GetByIdAync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            // Map the DTO to the entity
            var messageEntity = new MessageEntity
            {
                Message = message.Message,
                Date = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc),
                ApplicationUser = user, // Set the user object directly
                ApplicationUserId = message.ApplicationUserId
            };

            await messageRepository.AddMessage(messageEntity);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = messageEntity.Id}, messageEntity);
        }


    }
}
