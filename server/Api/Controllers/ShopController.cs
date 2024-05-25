using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Ubss.Api.Application.Models;
using Ubss.Api.Application.Services;
using Ubss.Server.Api.Hubs;

namespace Ubss.Server.Api.Controllers;

[ApiController]
[Route("api/shops")]
public sealed class ShopController : ControllerBase
{
    private readonly IShopService _service;

    private readonly IHubContext<EventHub, IEventHub> _hubContext;

    public ShopController(
        IShopService service,
        IHubContext<EventHub, IEventHub> hubContext)
    {
        _service = service;
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> Store([FromBody] Shop shop)
    {
        await _service.StoreAsync(shop);

        await _hubContext.Clients.All.ShopStored(shop);

        return Ok(shop.Id);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var shops = await _service.GetAsync();

        return Ok(shops);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
