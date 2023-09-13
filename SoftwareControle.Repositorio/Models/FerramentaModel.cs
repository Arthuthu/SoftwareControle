namespace SoftwareControle.Models;
public class FerramentaModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Disponivel { get; set; }
    public byte[]? Imagem { get; set; }
    public DateTime DataCriacao { get; set; }

    //Chave estrangeira
    public Guid UsuarioId { get; set; }


    // Propriedades de navegação
    public UsuarioModel? Usuario { get; set; }
    public List<OrdemModel>? Ordem { get; set; }
}
