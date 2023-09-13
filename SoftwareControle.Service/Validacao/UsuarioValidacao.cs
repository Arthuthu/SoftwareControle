﻿using FluentValidation;
using SoftwareControle.Models;

namespace SoftwareControle.Services.Validacao;

public class UsuarioValidacao : AbstractValidator<UsuarioModel>
{
    public UsuarioValidacao()
    {
        RuleFor(x => x.Usuario)
            .NotEmpty().WithMessage("Campo de usuario não pode estar vazio")
            .MinimumLength(5).WithMessage("Campo de usuário tem que ter no minimo 5 caracteres");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("O campo senha não pode estar vazio")
            .MinimumLength(8).WithMessage("O campo senha precisa ter no minimo 8 caracteres")
            .MaximumLength(20).WithMessage("O campo senha pode ter no maximo 20 caracteres");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O campo nome não pode estar vazio")
            .MinimumLength(3).WithMessage("O campo nome precisa ter no minimo 3 caracteres")
            .MaximumLength(70).WithMessage("O campo senha pode ter no maximo 70 caracteres");
    }
}
