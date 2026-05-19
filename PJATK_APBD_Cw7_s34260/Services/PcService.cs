using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34260.DTOs;
using PJATK_APBD_Cw7_s34260.exceptions;
using PJATK_APBD_Cw7_s34260.Infrastructure;
using PJATK_APBD_Cw7_s34260.Models;

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

    public async Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PcResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs.Where(Pc => Pc.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(e => e.Name, request.Name)
                .SetProperty(e => e.Weight, request.Weight)
                .SetProperty(e => e.Warranty, request.Warranty)
                .SetProperty(e => e.CreatedAt, request.CreatedAt)
                .SetProperty(e => e.Stock, request.Stock),
                cancellationToken
            );
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs.Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
        if (affectedRows == 0)
            throw new NotFoundException($"Pc with id {id} not found");
    }
}