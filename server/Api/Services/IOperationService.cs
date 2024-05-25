using Ubss.Server.Api.Models;
using Ubss.Server.Api.Payloads;

namespace Ubss.Server.Api.Services;

public interface IOperationService
{
    Task<IEnumerable<Operation>> GetAsync();

    Task<Operation> GetAsync(Guid id);

    Task StoreAsync(Operation operation);

    Task UpdateAsync(UpdateOperationRequest request);

    Task DeleteAsync(Guid id);
}
