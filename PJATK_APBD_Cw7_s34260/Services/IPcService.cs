using PJATK_APBD_Cw7_s34260.DTOs;

namespace PJATK_APBD_Cw7_s34260.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken);
}