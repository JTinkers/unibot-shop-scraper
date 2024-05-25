using Ubss.Api.Application.Models;

namespace Ubss.Api.Application.Services;

public interface IShopService
{
    Task StoreAsync(Shop shop);

    Task<Shop> GetAsync(Guid id);

    Task<IEnumerable<Shop>> GetAsync();

    Task DeleteAsync(Guid id);
}
