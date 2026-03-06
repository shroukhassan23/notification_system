using JupiterTask.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JupiterTask.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
     
        Task SendNotificationAsync(Notification notification);
    }
}