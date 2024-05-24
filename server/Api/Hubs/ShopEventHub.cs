using Microsoft.AspNetCore.SignalR;
using Ubss.Application.Models;

namespace Ubss.Server.Api.Hubs
{
    public class ShopEventHub : Hub<IShopEventHub>, IShopEventHub
    {
        public async Task SendShopStoredAsync(Shop shop)
        {
            await Clients.All.SendShopStoredAsync(shop);
        }
    }
}
