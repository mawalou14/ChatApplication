using AutoMapper;
using BaseLibrary.DTO;
using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
using ChatApplicationAPI.Repositories.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class Message : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IMessageRepository messageRepository;

        public Message(ApplicationDbContext dbContext, IMapper mapper, IMessageRepository messageRepository )
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var messages = await messageRepository.GetAllAsync();
            var getMessageDto = mapper.Map<List<MessageEntity>>(messages);
            return Ok(getMessageDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MessageDTO message)
        {
            var messageEntity = mapper.Map<MessageEntity>(message);
            await messageRepository.AddMessage(messageEntity);
            return Ok();
        }
    }
}
