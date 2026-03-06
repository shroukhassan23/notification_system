using JupiterTask.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JupiterTask.Infrastructure.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task AddAsync(Device device);
     
    }
}