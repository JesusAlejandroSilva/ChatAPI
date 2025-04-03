using Chat.Core.Entities;

namespace Chat.Infrastructure.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Mensaje>> GetMessagesBySalaAsync(int salaId);
        Task AddMessageAsync(Mensaje mensaje);
    }
}
