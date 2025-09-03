using Application.Features.Users.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Validation
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Debe incluir una mayúscula")
                .Matches("[a-z]").WithMessage("Debe incluir una minúscula")
                .Matches("[0-9]").WithMessage("Debe incluir un número")
                .Matches("[^a-zA-Z0-9]").WithMessage("Debe incluir un símbolo");
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Role).Must(r => new[] { "Admin", "Supervisor", "Employee" }.Contains(r))
                .WithMessage("Role inválido");
        }
    }
}
