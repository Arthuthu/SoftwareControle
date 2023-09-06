using FluentValidation;
using SoftwareControle.Models;

namespace SoftwareControle.Services.Validacao;

public class UsuarioValidacao : AbstractValidator<UsuarioModel>
{
    public UsuarioValidacao()
    {
    }
}
