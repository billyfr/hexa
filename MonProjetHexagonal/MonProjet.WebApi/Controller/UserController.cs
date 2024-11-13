// MonProjet.WebApi/Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using MonProjet.Application.Services;
using MonProjet.Core.Entities;

namespace MonProjet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // Autres méthodes...
    }
}
