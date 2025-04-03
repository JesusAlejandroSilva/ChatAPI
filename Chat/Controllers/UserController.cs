using Chat.Application.Services;
using Chat.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.ObtenerUsuarioPorId(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Usuario usuario)
        {
            try
            {
                await _userService.AgregarUsuario(usuario);
                return Ok(new { message = "Usuario registrado con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
