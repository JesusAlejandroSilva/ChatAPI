using Chat.Core.Entities;

namespace Chat.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> GetUserByIdAsync(int userId);
        Task<Usuario> GetUserByApodoAsync(string apodo);
        Task AddUserAsync(Usuario user);
    }
}
