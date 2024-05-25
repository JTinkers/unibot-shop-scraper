namespace Ubss.Application.Models;

public sealed class Item
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public long Price { get; set; }

    public long Value { get; set; }

    public Dictionary<string, string> Properties { get; set; }
}
