using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Models
{
    public record ClientCreateDto(string Dni, string Name, string ShippingAddress);

}
