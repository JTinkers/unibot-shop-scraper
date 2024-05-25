namespace Ubss.Server.Api.Models;

public sealed class Operation
{
    public Guid Id { get; }
        = Guid.NewGuid();

    public DateTime QueuedAt { get; }
        = DateTime.UtcNow;

    public OperationType Type { get; }

    public OperationStatus Status { get; set; }

    public string? Result { get; set; }
}
