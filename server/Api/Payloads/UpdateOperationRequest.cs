using Ubss.Server.Api.Models;

namespace Ubss.Server.Api.Payloads
{
    public class UpdateOperationRequest
    {
        public Guid Id { get; set; }

        public OperationStatus Status { get; set; }

        public string? Result { get; set; }
    }
}
