using Application.Features.Clients.Models;
using FluentValidation;

namespace Application.Features.Clients.Validation;

public class ClientUpdateValidator : AbstractValidator<ClientUpdateDto>
{
    public ClientUpdateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(120);
        RuleFor(x => x.ShippingAddress).MaximumLength(200);
    }
}
