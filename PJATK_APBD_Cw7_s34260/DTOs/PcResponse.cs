namespace PJATK_APBD_Cw7_s34260.DTOs;

public record PcResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );