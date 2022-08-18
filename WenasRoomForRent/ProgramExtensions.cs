using InMemory = WenasRoomForRent.Repository.InMemory;
using SqlDb = WenasRoomForRent.Repository.SqlDB;
using WenasRoomForRent.Repository;
using WenasRoomForRent.Services;
using WenasRoomForRent.Api.Filters;
using WenasRoomForRent.Repository.InMemory;

namespace WenasRoomForRent.Api;

public static class ProgramExtensions
{
    public static void AddInMemoryRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRoomRepository, InMemory.RoomRepository>();
        services.AddScoped<IProfileRepository, InMemory.ProfileRepository>();
        services.AddScoped<IRentRepository, InMemory.RentRepository>();
        services.AddScoped<IPaymentRepository, InMemory.PaymentRepository>();
    }

    public static void AddSqlDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRoomRepository, SqlDb.RoomRepository>();
        services.AddScoped<IProfileRepository, SqlDb.ProfileRepository>();
        services.AddScoped<IRentRepository, SqlDb.RentRepository>();
        services.AddScoped<IPaymentRepository, SqlDb.PaymentRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IRentService, RentService>();
        services.AddScoped<IPaymentService, PaymentService>();
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
