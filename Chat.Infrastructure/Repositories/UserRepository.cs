using Chat.Core.Entities;
using Chat.Infrastructure.Data;
using Chat.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatDbContext _context;

        public UserRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _context.Usuarios.FindAsync(userId)
                    ?? throw new KeyNotFoundException("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por ID: {ex.Message}");
            }
        }

        public async Task<Usuario> GetUserByApodoAsync(string apodo)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Apodo == apodo);
                return usuario ?? throw new KeyNotFoundException("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por apodo: {ex.Message}");
            }
        }

        public async Task AddUserAsync(Usuario user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException(nameof(user));

                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar usuario: {ex.Message}");
            }
        }
    }
}