using dotnet_registration_api.Data.Entities;
using dotnet_registration_api.Data.Models;
using dotnet_registration_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_registration_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody]LoginRequest model)
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody]RegisterRequest model)
        {
            var newUser = await this._userService.Register(model);

            return Ok(newUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await this._userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await this._userService.GetById(id);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, [FromBody]UpdateRequest model)
        {
            var updatedUser = await this._userService.Update(id, model);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
