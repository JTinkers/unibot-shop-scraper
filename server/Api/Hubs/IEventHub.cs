﻿using Ubss.Application.Models;

namespace Ubss.Server.Api.Hubs
{
    public interface IEventHub
    {
        public Task ShopStored(Shop shop);
    }
}
