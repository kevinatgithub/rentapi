//using InMemory = KevApp.Repository.InMemory;
//using SqlDb = KevApp.Repository.SqlDB;
using KevApp.Repository;
using KevApp.Services;
using KevApp.Api.Filters;
using KevApp.Repository.InMemory;

namespace KevApp.Api;

public static class ProgramExtensions
{
    public static void AddInMemoryRepositories(this IServiceCollection services)
    {
        
    }

    public static void AddSqlDbRepositories(this IServiceCollection services)
    {
        
    }

    public static void AddServices(this IServiceCollection services)
    {
        
    }

    public static void AddRequestLogger(this IServiceCollection services)
    {
        services.AddSingleton<AppInMemoryContext>();
        services.AddScoped<IRequestLogRepository, RequestLogRepository>();
        services.AddScoped<IRequestLogService, RequestLogService>();
        services.AddScoped<RequestLoggerActionFilterAttribute>();
        services.AddScoped<RequestLogger>();
    }

    public static void AddRequestLogger(this IServiceCollection services, bool _)
    {
        services.AddScoped<IRequestLogRepository, RequestLogRepository>();
        services.AddScoped<IRequestLogService, RequestLogService>();
        services.AddScoped<RequestLoggerActionFilterAttribute>();
        services.AddScoped<RequestLogger>();
    }
}
