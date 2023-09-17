using SoftwareControle.Models;

namespace SoftwareControle.Repositorio.DomainMapper;

public static class FerramentaModelMapper
{
    public static FerramentaModel MapFerramentaModel(this FerramentaModel ferramentaModel)
    {
        return new FerramentaModel()
        {
            Id = ferramentaModel.Id,
            Nome = ferramentaModel.Nome,
            Descricao = ferramentaModel.Descricao,
            Disponivel = ferramentaModel.Disponivel,
            Imagem = ferramentaModel.Imagem,
            DataCriacao = ferramentaModel.DataCriacao,
            DataAtualizacao = ferramentaModel.DataAtualizacao,
            UsuarioId = ferramentaModel.UsuarioId,
            Ordem = ferramentaModel.Ordem,
            Usuario = ferramentaModel.Usuario
        };

    }
}
