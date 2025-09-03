using Application.Features.Clients.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Validation
{
    public class ClientCreateValidator : AbstractValidator<ClientCreateDto>
    {
        public ClientCreateValidator()
        {
            RuleFor(x => x.Dni).NotEmpty().Length(7, 12);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(120);
            RuleFor(x => x.ShippingAddress).MaximumLength(200);
        }
    }
}
