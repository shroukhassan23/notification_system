using JupiterTask.Core.Entities;
using JupiterTask.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JupiterTask.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _deviceRepository.GetAllAsync();
        }

  

        public async Task RegisterDeviceAsync(Device device)
        {
            var devices = await _deviceRepository.GetAllAsync();

            var existingDevice = devices.FirstOrDefault(d => d.DeviceToken == device.DeviceToken);

            if (existingDevice != null)
            {
                return; // الجهاز متسجل بالفعل
            }
            device.RegisteredAt = DateTime.Now;
            await _deviceRepository.AddAsync(device);
        }
    }
}