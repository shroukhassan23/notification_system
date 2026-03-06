// NotificationLogRepository.cs
using JupiterTask.Core.Entities;
using JupiterTask.Infrastructure.Data; // لو عندك DbContext هنا
using JupiterTask.Infrastructure.Repositories;


public class NotificationLogRepository : INotificationLogRepository
{
    private readonly ApplicationDbContext _context;

    public NotificationLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(NotificationLog log)
    {
        _context.NotificationLogs.Add(log); // إضافة سجل
        await _context.SaveChangesAsync();   // حفظ في DB
    }
}