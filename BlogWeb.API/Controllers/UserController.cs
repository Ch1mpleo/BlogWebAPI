using BlogWeb.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<IdentityUser>> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("username/{username}")]

        public async Task<ActionResult<IdentityUser>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();

            }
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<IdentityUser>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpPost]
        public async Task<ActionResult<IdentityUser>> CreateUser([FromBody] IdentityUser user, string password)
        {
            var createdUser = await _userService.CreateUserAsync(user, password);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IdentityUser>> UpdateUser(string id, [FromBody] IdentityUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUserAsync(user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userService.DeleteUserAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors); // Return Identity errors if deletion fails
            }

            return NoContent();
        }
    }
}
