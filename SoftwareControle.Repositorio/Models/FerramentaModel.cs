namespace SoftwareControle.Models;
public class FerramentaModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Disponivel { get; set; }
    public byte[]? Imagem { get; set; }

    // Propriedades de navegação
    public List<UsuarioModel>? Usuarios { get; set; }
    public List<RelatorioModel>? Relatorios { get; set; }
    public List<OrdemModel> CriarOrdens { get; set; } = new List<OrdemModel>();
}
