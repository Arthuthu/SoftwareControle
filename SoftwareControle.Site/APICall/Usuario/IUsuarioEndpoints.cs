using SoftwareControle.Site.Models;

namespace SoftwareControle.Site.APICall.Usuario
{
    public interface IUsuarioEndpoints
    {
        Task<List<UsuarioModel>?> Buscar();
        Task<UsuarioModel?> BuscarPorId(Guid id);
        Task<string?> Criar(UsuarioModel usuario);
        Task<string?> AtualizarUsuario(UsuarioModel usuario);
        Task<string?> DeletarUsuario(Guid id);
    }
}