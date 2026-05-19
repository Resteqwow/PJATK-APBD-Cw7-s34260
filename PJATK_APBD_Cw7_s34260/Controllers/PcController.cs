using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s34260.Services;

namespace PJATK_APBD_Cw7_s34260.Controllers;



[ApiController]
[Route("api/[controller]")]
public class PcController(IPcService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        return Ok(await service.GetByIdAsync(id,cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Add()
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update()
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }


}