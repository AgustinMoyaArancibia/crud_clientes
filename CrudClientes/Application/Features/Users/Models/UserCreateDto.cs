using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Models
{
    public record UserCreateDto(string Email, string Password, string FullName, string Role);
}
