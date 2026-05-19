namespace PJATK_APBD_Cw7_s34260.DTOs;

public record PcGetByIdResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<ComponentsResponse> Components
    );