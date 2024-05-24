namespace Ubss.Application.Models;

public sealed class Shop
{
    public Guid Id { get; set; } 
        = Guid.NewGuid();

    public string Name { get; set; }

    public Player Owner { get; set; }

    public IEnumerable<Item> Items { get; set; }
}
