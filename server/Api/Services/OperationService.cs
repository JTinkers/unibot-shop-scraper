using Ubss.Server.Api.Models;
using Ubss.Server.Api.Payloads;

namespace Ubss.Server.Api.Services;

internal sealed class OperationService : IOperationService
{
    private readonly List<Operation> _operations;

    public OperationService()
    {
        _operations = new();
    }

    public async Task<IEnumerable<Operation>> GetAsync() 
        => _operations.AsEnumerable();

    public async Task<Operation> GetAsync(Guid id)
    {
        var operation = _operations
            .Find(x => x.Id == id);

        return operation;
    }

    public async Task StoreAsync(Operation operation) 
        => _operations.Add(operation);

    public async Task UpdateAsync(UpdateOperationRequest request)
    {
        var operation = await 
            GetAsync(request.Id);

        operation.Status = request.Status;
        operation.Result = request.Result;
    }

    public async Task DeleteAsync(Guid id)
    {
        var operation = await GetAsync(id);

        _operations.Remove(operation);
    }
}
