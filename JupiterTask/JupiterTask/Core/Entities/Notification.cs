namespace JupiterTask.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string SentBy { get; set; }

        public bool IsSent { get; set; }
    }
}
