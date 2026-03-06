using JupiterTask.Core.Entities;
using JupiterTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JupiterTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/notification
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        // POST: api/notification/send
        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] Notification notification)
        {
            if (notification == null)
                return BadRequest();

            await _notificationService.SendNotificationAsync(notification);
   
            return Ok(new { message = "Notification saved and ready to send." });
        }
    }
}