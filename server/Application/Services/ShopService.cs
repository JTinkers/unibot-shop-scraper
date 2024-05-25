using Ubss.Api.Application.Models;

namespace Ubss.Api.Application.Services;

internal class ShopService : IShopService
{
    private List<Shop> _shops;

    public ShopService()
    {
        _shops = new();
    }

    public async Task<IEnumerable<Shop>> GetAsync()
        => _shops.AsEnumerable();

    public async Task<Shop> GetAsync(Guid id)
    {
        var shop = _shops
            .Find(x => x.Id == id);

        return shop;
    }

    public async Task StoreAsync(Shop shop)
    {
        var previous = _shops
            .Where(x => x.Name == shop.Name)
            .Where(x => x.Owner.Name == shop.Owner.Name)
            .FirstOrDefault();

        if (previous is not null)
            throw new InvalidOperationException("Duplicate entry exists");

        _shops.Add(shop);
    }

    public async Task DeleteAsync(Guid id)
    {
        var shop = await GetAsync(id);

        _shops.Remove(shop);
    }
}
