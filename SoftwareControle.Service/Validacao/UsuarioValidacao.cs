using FluentValidation;
using SoftwareControle.Models;

namespace SoftwareControle.Services.Validacao;

public class UsuarioValidacao : AbstractValidator<UsuarioModel>
{
    public UsuarioValidacao()
    {
        RuleFor(x => x.Usuario)
            .NotEmpty().WithMessage("Campo de usuario não pode estar vazio")
            .MinimumLength(5).WithMessage("Campo de usuário tem que ter no minimo 5 caracteres");
    }
}
