using Ubss.Api.Application.Services;
using Ubss.Server.Api.Hubs;
using Ubss.Server.Api.Services;

namespace Ubss.Server.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<IShopService, ShopService>();
        builder.Services.AddSingleton<IOperationService, OperationService>();
        builder.Services.AddControllers();
        builder.Services.AddSignalR();

        var app = builder.Build();

        app.UseCors(policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

        app.MapControllers();
        app.MapHub<EventHub>("/events");
        app.Run();
    }
}
