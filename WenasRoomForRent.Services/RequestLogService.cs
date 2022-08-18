using WenasRoomForRent.Repository;

namespace WenasRoomForRent.Services;

public class RequestLogService : IRequestLogService
{
    private readonly IRequestLogRepository requestLogRepository;

    public RequestLogService(IRequestLogRepository requestLogRepository)
    {
        this.requestLogRepository = requestLogRepository ?? throw new ArgumentNullException(nameof(requestLogRepository));
    }

    public List<(string, DateTime)> GetLogs() => requestLogRepository.GetAll();

    public void Log(string message) => requestLogRepository.Log(message);
}
