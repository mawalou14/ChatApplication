using AutoMapper;
using BaseLibrary.DTO.ApplicationUserDTOs;
using BaseLibrary.Entities;
using ChatApplicationAPI.DataAccessLayer;
using ChatApplicationAPI.Repositories.ApplicationUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IApplicationUserRepository userRepository;

        public ApplicationUserController(ApplicationDbContext dbContext, IMapper mapper, IApplicationUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usersModel = await userRepository.GetAllAsync();
            var UserDTO = mapper.Map<List<GetApplicationUsersDTO>>(usersModel);
            return Ok(UserDTO);
        }

        [HttpGet("{id:guid}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var foundUser = await userRepository.GetByIdAync(id);
            if(foundUser == null)
            {
                return NotFound();
            }
            var user = mapper.Map<GetApplicationUsersDTO>(foundUser);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddApplicationUsersDTO newUser)
        {
            var applicationUserModel = mapper.Map<ApplicationUserEntity>(newUser);
            var createdUser = await userRepository.AddAsync(applicationUserModel);
            var applicationUserDto = mapper.Map<GetApplicationUsersDTO>(createdUser);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = applicationUserModel.Id}, applicationUserDto);
        }
    }
}
