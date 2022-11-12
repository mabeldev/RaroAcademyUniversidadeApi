using demys_universidade.Domain.Entities;
using demys_universidade.Domain.Interfaces.Repositories;
using demys_universidade.Domain.Interfaces.Services;

namespace demys_universidade.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository) { }

        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(
                usuario.Senha,
                BCrypt.Net.BCrypt.GenerateSalt()
            );
            await AdicionarAsync(usuario);
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(
                usuario.Senha,
                BCrypt.Net.BCrypt.GenerateSalt()
            );
            await AlterarAsync(usuario);
        }

        public async Task<Usuario> GetPorNome(string nome)
        {
            return await base.ObterAsync(p => p.Nome == nome);
        }

    }
}
