namespace WenasRoomForRent.Services;

public interface IRequestLogService
{
    void Log(string message);
    List<(string,DateTime)> GetLogs();
}
