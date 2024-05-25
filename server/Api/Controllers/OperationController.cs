using Microsoft.AspNetCore.Mvc;
using Ubss.Server.Api.Models;
using Ubss.Server.Api.Payloads;
using Ubss.Server.Api.Services;

namespace Ubss.Server.Api.Controllers;

[ApiController]
[Route("api/operations")]
public class OperationController : ControllerBase
{
    private readonly IOperationService _service;

    public OperationController(IOperationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Store([FromBody] Operation operation)
    {
        await _service.StoreAsync(operation);

        return Ok(operation.Id);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OperationStatus? whereStatus)
    {
        var operations = await _service.GetAsync();

        if (whereStatus is not null)
            operations = operations.Where(x => x.Status == whereStatus);

        return Ok(operations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var operation = await _service.GetAsync(id);

        return Ok(operation);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationRequest request)
    {
        await _service.UpdateAsync(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
