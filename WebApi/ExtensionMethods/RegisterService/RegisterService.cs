using Infrastructure.Context;
using Infrastructure.Context;
using Infrastructure.Services.UserService;
using Infrastructure.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace WebApi.ExtensionMethods.RegisterService;

public static class RegisterService
{
    public static void AddRegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(configure =>
            configure.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IUserService, UserService>();
    }
}