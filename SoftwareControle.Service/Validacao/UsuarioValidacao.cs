using FluentValidation;
using SoftwareControle.Models;

namespace HFAcademia.Services.Validacao;

public class UsuarioValidacao : AbstractValidator<UsuarioModel>
{
    public UsuarioValidacao()
    {
    }
}
