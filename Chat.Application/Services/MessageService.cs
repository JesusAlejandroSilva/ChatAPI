using Chat.Core.Entities;
using Chat.Infrastructure.Repositories.Interfaces;

namespace Chat.Application.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Mensaje>> ObtenerMensajesPorSala(int salaId)
        {
            if (salaId <= 0) throw new ArgumentException("ID de sala no válido.");

            return await _messageRepository.GetMessagesBySalaAsync(salaId);
        }

        public async Task EnviarMensaje(Mensaje mensaje)
        {
            if (string.IsNullOrWhiteSpace(mensaje.Texto))
                throw new ArgumentException("El mensaje no puede estar vacío.");

            await _messageRepository.AddMessageAsync(mensaje);
        }
    }
}
