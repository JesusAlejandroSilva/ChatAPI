using Chat.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
    }
}
