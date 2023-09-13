namespace SoftwareControle.Models;

public class OrdemModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string NivelUrgencia { get; set; } = string.Empty;
    public string Situacao { get; set; } = string.Empty;
    public DateTime DataPrazoMaximo { get; set; }
    public DateTime DataCriacao { get; set; }    

    //Chaves estrangeira
    public Guid UsuarioId { get; set; }
    public Guid FerramentaId { get; set; }
}