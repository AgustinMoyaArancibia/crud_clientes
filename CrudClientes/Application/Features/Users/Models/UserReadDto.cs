using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Models
{
    public record UserReadDto(int Id, string Email, string FullName, string Role, bool Active, DateTime CreatedAt);
}
