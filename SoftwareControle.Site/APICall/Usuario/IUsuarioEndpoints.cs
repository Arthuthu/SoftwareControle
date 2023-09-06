using SoftwareControle.Site.Models;

namespace SoftwareControle.Site.APICall.Usuario
{
    public interface IUsuarioEndpoints
    {
        Task<string?> AtualizarUsuario(UsuarioModel usuario);
        Task<UsuarioModel?> BuscarPorId(Guid id);
        Task<List<UsuarioModel>?> BuscarUsuarios();
        Task<string?> Criar(UsuarioModel usuario);
        Task<string?> DeletarUsuario(Guid id);
    }
}