namespace PJATK_APBD_Cw7_s34260.DTOs;

public record ComponentsResponse(
    int Amount,
    string Code,
    string Name,
    string Description,
    ManufacturerResponse Manufacturer,
    ComponentTypeResponse ComponentType
    );