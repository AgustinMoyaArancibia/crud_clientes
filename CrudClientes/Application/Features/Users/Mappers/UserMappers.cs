using Application.Features.Users.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Mappers
{
    public static class UserMappers
    {
        public static UserReadDto ToReadDto(this User e)
            => new(e.Id, e.Email, e.FullName, e.Role, e.Active, e.CreatedAt);
    }
}
