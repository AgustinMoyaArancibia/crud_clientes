using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clients.Models
{
    public record ClientUpdateDto(string Name, string ShippingAddress, bool Active);

}
