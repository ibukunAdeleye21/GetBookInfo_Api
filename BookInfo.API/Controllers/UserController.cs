using BookInfo.API.Entities;
using BookInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateUser(model.Username, model.Password,
                        model.FirstName, model.LastName, model.Book);
                    return Ok("User Successfully Created");
                }
                // The message "This User exists already" when existingUser is not null will be caught here
                catch (Exception ex) 
                {
                    // Handle exception (e.g., user already exists)
                    return BadRequest(new { message = ex.Message });
                }
            }

            return BadRequest(ModelState);
        }
    }
}
