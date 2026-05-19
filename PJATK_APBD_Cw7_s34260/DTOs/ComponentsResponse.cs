namespace PJATK_APBD_Cw7_s34260.DTOs;

public record ComponentsResponse(
    int Amount,
    ComponentResponse Component,
    ManufacturerResponse Manufacturer,
    ComponentTypeResponse ComponentType
    );