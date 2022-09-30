namespace KevApp.Repository;

public class AppInMemoryContext
{
    public List<(string, DateTime)> RequestLogs = new List<(string, DateTime)>();
}
