using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34260.DTOs;
using PJATK_APBD_Cw7_s34260.exceptions;
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

    public async Task<PcGetByIdResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
                   .Where(Pc => Pc.Id == id)
                   .Select(Pc => new PcGetByIdResponse(
                       Pc.Id,
                       Pc.Name,
                       Pc.Weight,
                       Pc.Warranty,
                       Pc.CreatedAt,
                       Pc.Stock,
                       Pc.PCComponents.Select(Comp => new ComponentsResponse(
                               
                               Comp.Amount,
                               
                               new ComponentResponse(
                               Comp.Components.Code,
                               Comp.Components.Name,
                               Comp.Components.Description
                               ),
                               new ManufacturerResponse(
                                   Comp.Components.ComponentManufacturers.Id,
                                   Comp.Components.ComponentManufacturers.Abbreviation,
                                   Comp.Components.ComponentManufacturers.FullName,
                                   Comp.Components.ComponentManufacturers.FoundationDate
                               ),
                               new ComponentTypeResponse(
                                   Comp.Components.ComponentTypes.Id,
                                   Comp.Components.ComponentTypes.Abbreviation,
                                   Comp.Components.ComponentTypes.Name
                               )
                           ))
                       )).FirstOrDefaultAsync(cancellationToken)
               ?? throw new NotFoundException($"Pc with id {id} not found");

    }
}