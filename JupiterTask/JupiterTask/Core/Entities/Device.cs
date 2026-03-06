namespace JupiterTask.Core.Entities
{
    public class Device
    {
        public int Id { get; set; }

        public required string DeviceToken { get; set; }

        public required string DeviceName { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
