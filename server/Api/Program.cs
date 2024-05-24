using Ubss.Api.Application.Services;
using Ubss.Server.Api.Hubs;

namespace Ubss.Server.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<IShopService, ShopService>();
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
