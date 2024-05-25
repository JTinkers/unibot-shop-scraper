using Microsoft.AspNetCore.SignalR;
using Ubss.Api.Application.Models;

namespace Ubss.Server.Api.Hubs;

public class EventHub : Hub<IEventHub>, IEventHub
{
    public async Task ShopStored(Shop shop)
    {
        await Clients.All.ShopStored(shop);
    }
}
