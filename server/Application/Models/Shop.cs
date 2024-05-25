namespace Ubss.Api.Application.Models;

public sealed class Shop
{
    public Guid Id { get; }
        = Guid.NewGuid();

    public DateTime StoredAt { get; }
        = DateTime.UtcNow;

    public Position Position { get; set; }

    public string Name { get; set; }

    public Player Owner { get; set; }

    public IEnumerable<Item> Items { get; set; }
}
