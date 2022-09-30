namespace KevApp.Repository.InMemory;

public class RequestLogRepository : IRequestLogRepository
{
    private readonly AppInMemoryContext context;

    public RequestLogRepository(AppInMemoryContext context)
    {
        this.context = context;
    }

    public List<(string, DateTime)> GetAll() => context.RequestLogs;

    public void Log(string action)
    {
        if (context.RequestLogs.Any(l => l.Item1 == action))
        {
            var log = context.RequestLogs.Find(l => l.Item1 == action);
            if (log.Item1 != null)
                   log.Item2 = DateTime.UtcNow;
            else
                context.RequestLogs.Add((action, DateTime.UtcNow));
        }
        else
        {
            context.RequestLogs.Add((action, DateTime.UtcNow));
        }
    }
}
