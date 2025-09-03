using Application.Common.Paging;
using Application.Common.Results;
using Application.Features.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Services
{
    public interface IUserService
    {
        Task<PagedResult<UserReadDto>> GetAsync(PagedRequest request, CancellationToken ct = default);
        Task<Result<UserReadDto>> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Result<int>> CreateAsync(UserCreateDto dto, CancellationToken ct = default);
        Task<Result<bool>> UpdateAsync(int id, UserUpdateDto dto, CancellationToken ct = default);
        Task<Result<bool>> DeleteAsync(int id, CancellationToken ct = default);
    }
}
