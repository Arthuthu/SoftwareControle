namespace SoftwareControle.Models;

public class RelatorioModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string? FerramentaNome { get; set; } = string.Empty;
    public string? UsuarioNome { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
}
