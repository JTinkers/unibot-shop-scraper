using Ubss.Api.Application.Models;

namespace Ubss.Application.Models;

public sealed class Shop
{
    public Guid Id { get; set; } 
        = Guid.NewGuid();

    public DateTime StoredAt { get; set; }
        = DateTime.UtcNow;

    public Position Position { get; set; }

    public string Name { get; set; }

    public Player Owner { get; set; }

    public IEnumerable<Item> Items { get; set; }
}
