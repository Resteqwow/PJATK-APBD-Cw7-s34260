using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34260.DTOs;
using PJATK_APBD_Cw7_s34260.Infrastructure;

namespace PJATK_APBD_Cw7_s34260.Services;

public class PcService(DatabaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(Pc => new PcResponse(
            Pc.Id,
            Pc.Name,
            Pc.Weight,
            Pc.Warranty,
            Pc.CreatedAt,
            Pc.Stock
            )).ToListAsync(cancellationToken);
    }
}