﻿using Ubss.Application.Models;

namespace Ubss.Api.Application.Services;

internal class ShopService : IShopService
{
    private List<Shop> _shops;

    public ShopService()
    {
        _shops = new List<Shop>();
    }

    public async Task StoreAsync(Shop shop)
    {
        var previous = _shops
            .Where(x => x.Name == shop.Name)
            .Where(x => x.Owner.Name == shop.Owner.Name)
            .FirstOrDefault();

        if (previous is not null)
            await DeleteAsync(previous.Id);

        _shops.Add(shop);
    }

    public async Task<Shop> GetAsync(Guid id)
    {
        var shop = _shops
            .Find(x => x.Id == id);

        return shop;
    }

    public async Task<IEnumerable<Shop>> GetAsync()
    {
        return _shops.AsEnumerable();
    }

    public async Task DeleteAsync(Guid id)
    {
        var shop = await GetAsync(id);

        _shops.Remove(shop);
    }
}