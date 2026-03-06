using JupiterTask.Core.Entities;

public class NotificationLog
{
    public int Id { get; set; }
    public int NotificationId { get; set; }
    public Notification Notification { get; set; } = null!;

    public int DeviceId { get; set; }
    public Device Device { get; set; } = null!;
    public DateTime SentAt { get; set; } = DateTime.Now;
    public required string Status { get; set; }
}