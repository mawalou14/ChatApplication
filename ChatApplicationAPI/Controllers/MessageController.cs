using AutoMapper;
using BaseLibrary.DTO.messageDTOs;
using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
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

        public MessageController(ApplicationDbContext dbContext, IMapper mapper, IMessageRepository messageRepository )
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var messages = await messageRepository.GetAllAsync();
            var getMessageDto = mapper.Map<List<GetMessageDTO>>(messages);
            return Ok(getMessageDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddMessageDTO message)
        {
            var messageEntity = mapper.Map<MessageEntity>(message);
            await messageRepository.AddMessage(messageEntity);
            return Ok();
        }


    }
}
