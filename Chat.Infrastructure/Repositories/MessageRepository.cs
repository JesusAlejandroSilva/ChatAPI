using Chat.Core.Entities;
using Chat.Infrastructure.Data;
using Chat.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatDbContext _context;

        public MessageRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mensaje>> GetMessagesBySalaAsync(int salaId)
        {
            try
            {
                return await _context.Mensajes
                    .Where(m => m.SalaId == salaId)
                    .OrderBy(m => m.Fecha)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener mensajes: {ex.Message}");
            }
        }

        public async Task AddMessageAsync(Mensaje mensaje)
        {
            try
            {
                if (mensaje == null) throw new ArgumentNullException(nameof(mensaje));

                await _context.Mensajes.AddAsync(mensaje);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar mensaje: {ex.Message}");
            }
        }
    }
}
