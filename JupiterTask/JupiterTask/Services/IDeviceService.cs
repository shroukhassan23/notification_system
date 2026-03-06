using JupiterTask.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JupiterTask.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
 
        Task RegisterDeviceAsync(Device device);
    }
}