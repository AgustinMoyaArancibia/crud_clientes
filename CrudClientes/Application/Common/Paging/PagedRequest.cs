using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Paging;

public record PagedRequest(int Page = 1, int Size = 10, string? Search = null)
{
    public int PageSafe => Math.Max(1, Page);
    public int SizeSafe => Math.Clamp(Size, 1, 100);
}

