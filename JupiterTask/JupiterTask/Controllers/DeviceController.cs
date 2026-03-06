using JupiterTask.Core.Entities;
using JupiterTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JupiterTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // POST: api/Device/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Device device)
        {
            if (device == null)
                return BadRequest();

            await _deviceService.RegisterDeviceAsync(device);
            return Ok(new { message = "Device registered successfully." });
        }

    }
}