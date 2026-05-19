using PJATK_APBD_Cw7_s34260.DTOs;

namespace PJATK_APBD_Cw7_s34260.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcGetByIdResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}