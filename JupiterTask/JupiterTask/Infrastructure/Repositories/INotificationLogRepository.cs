namespace JupiterTask.Infrastructure.Repositories
{
    public interface INotificationLogRepository
    {
        Task AddAsync(NotificationLog log);
    }
}
