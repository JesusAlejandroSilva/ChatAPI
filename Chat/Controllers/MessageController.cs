using Chat.Application.Services;
using Chat.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{salaId}")]
        public async Task<IActionResult> GetMessages(int salaId)
        {
            try
            {
                var messages = await _messageService.ObtenerMensajesPorSala(salaId);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] Mensaje mensaje)
        {
            try
            {
                await _messageService.EnviarMensaje(mensaje);
                return Ok(new { message = "Mensaje enviado." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
