using Application.Common.Paging;
using Application.Common.Results;
using Application.Features.Clients.Models;

namespace Application.Features.Clients.Services;

public interface IClientService
{
    Task<PagedResult<ClientReadDto>> GetAsync(PagedRequest request, CancellationToken ct = default);
    Task<Result<ClientReadDto>> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Result<int>> CreateAsync(ClientCreateDto dto, CancellationToken ct = default);
    Task<Result<bool>> UpdateAsync(int id, ClientUpdateDto dto, CancellationToken ct = default);
    Task<Result<bool>> DeleteAsync(int id, CancellationToken ct = default);
}
