using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Model;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> findAllUsers() 
        {
            List<User> usersList  = await _userRepository.findAllUsers();
            return Ok(usersList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> findById(int id)
        {
            User user = await _userRepository.findById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
          User _user = await _userRepository.add(user);
            return Ok(_user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] User user, int id)
        {
            user.Id = id;
            User _user = await _userRepository.update(user,id);
            return Ok(_user);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int id)
        {
            bool deleted = await _userRepository.remove(id);
            return Ok(deleted);
        }
    }
}
