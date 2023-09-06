namespace SoftwareControle.Models;

public class OrdemModel
{
    public Guid Id { get; set; }
    public Guid FerramentaId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public DateTime DataPrazoMaximo { get; set; }
    public string NivelUrgencia { get; set; } = string.Empty;
    public bool Concluida { get; set; } = false;

    // Propriedades de navegação
    public FerramentaModel? Ferramenta { get; set; }
    public List<UsuarioModel>? Usuarios { get; set; }
    public List<RelatorioModel>? Relatorios { get; set; }
}