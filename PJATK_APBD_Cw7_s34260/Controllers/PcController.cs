using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s34260.DTOs;
using PJATK_APBD_Cw7_s34260.exceptions;
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
        try
        {
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreatePcRequest request,
        CancellationToken cancellationToken
        )
    {
        var student = await service.AddAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePcRequest request, CancellationToken cancellationToken)
    { 
        try
        {
            await service.UpdateAsync(id, request, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }


}