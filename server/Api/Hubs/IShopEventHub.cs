using Ubss.Application.Models;

namespace Ubss.Server.Api.Hubs
{
    public interface IShopEventHub
    {
        public Task SendShopStoredAsync(Shop shop);
    }
}
