namespace SoftwareControle.Site.Models;

public class RelatorioModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string? FerramentaNome { get; set; } = string.Empty;
    public string? UsuarioNome { get; set; } = string.Empty;
    public Guid? FerramentaId { get; set; }
    public Guid? OrdemId { get; set; }
    public Guid? UsuarioId { get; set; }
    public DateTime DataCriacao { get; set; }
}
