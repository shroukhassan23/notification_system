using JupiterTask.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JupiterTask.Infrastructure.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();
     
        Task AddAsync(Notification notification);
        Task UpdateAsync(Notification notification);

    }
}