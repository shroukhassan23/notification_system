using FirebaseAdmin.Messaging;
using JupiterTask.Core.Entities;
using JupiterTask.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseNotification = FirebaseAdmin.Messaging.Notification;
namespace JupiterTask.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly INotificationLogRepository _notificationLogRepository;

        public NotificationService(INotificationRepository notificationRepository, IDeviceRepository deviceRepository, INotificationLogRepository notificationLogRepository)
        {
            _notificationRepository = notificationRepository;
            _deviceRepository = deviceRepository;
            _notificationLogRepository = notificationLogRepository;
        }

        public async Task<IEnumerable<Core.Entities.Notification>> GetAllNotificationsAsync()
        {
            return await _notificationRepository.GetAllAsync();
        }

    

        public async Task SendNotificationAsync(Core.Entities.Notification notification)
        {
            notification.CreatedAt = DateTime.Now;
            notification.IsSent = false;

            await _notificationRepository.AddAsync(notification);

            var devices = await _deviceRepository.GetAllAsync();

            foreach (var device in devices)
            {
                var log = new NotificationLog
                {
                    NotificationId = notification.Id,
                    DeviceId = device.Id,
                    SentAt = DateTime.Now,
                    Status = "Pending"
                };

                try
                {
                    var message = new Message()
                    {
                        Token = device.DeviceToken,
                        Notification = new FirebaseNotification
                        {
                            Title = notification.Title,
                            Body = notification.Body
                        }
                    };

                    await FirebaseMessaging.DefaultInstance.SendAsync(message);

                    log.Status = "Sent";
                }
                catch
                {
                    log.Status = "Failed";
                }

                // احفظ كل log بعد كل محاولة
                await _notificationLogRepository.AddAsync(log);
            }

            notification.IsSent = true;
            //update status
            await _notificationRepository.UpdateAsync(notification);
        }

   

        
    }
}