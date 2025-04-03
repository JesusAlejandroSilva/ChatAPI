using Chat.Core.Entities;
using Chat.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            if (id <= 0) throw new ArgumentException("ID de usuario no válido.");

            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<Usuario> ObtenerUsuarioPorApodo(string apodo)
        {
            if (string.IsNullOrWhiteSpace(apodo))
                throw new ArgumentException("El apodo no puede estar vacío.");

            return await _userRepository.GetUserByApodoAsync(apodo);
        }

        public async Task AgregarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Apodo))
                throw new ArgumentException("El apodo es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
                throw new ArgumentException("El nombre completo es obligatorio.");

            await _userRepository.AddUserAsync(usuario);
        }
    }
}
