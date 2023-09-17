using SoftwareControle.Models;

namespace SoftwareControle.Repositorio.DomainMapper;

public static class OrdemModelMapper
{
    public static OrdemModel MapOrdemModel(this OrdemModel ordemModel)
    {
        return new OrdemModel()
        {
            Id = ordemModel.Id,
            Descricao = ordemModel.Descricao,
            NivelUrgencia = ordemModel.NivelUrgencia,
            Situacao = ordemModel.Situacao,
            NomeFerramenta = ordemModel.NomeFerramenta,
            NomeResponsavel = ordemModel.NomeResponsavel,
            DataPrazoMaximo = ordemModel.DataPrazoMaximo,
            DataCriacao = ordemModel.DataCriacao,
            DataAtualizacao = ordemModel.DataAtualizacao,
            UsuarioId = ordemModel.UsuarioId,
            FerramentaId = ordemModel.FerramentaId,
            Ferramenta = ordemModel.Ferramenta,
            Usuario = ordemModel.Usuario
        };
    }
}
