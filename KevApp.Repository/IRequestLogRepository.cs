namespace KevApp.Repository;

public interface IRequestLogRepository
{
    public void Log(string action);
    public List<(string,DateTime)> GetAll();
}
