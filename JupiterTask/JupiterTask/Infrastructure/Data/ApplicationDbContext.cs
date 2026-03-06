using JupiterTask.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JupiterTask.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NotificationLog>()
                .HasOne(nl => nl.Notification)
                .WithMany() 
                .HasForeignKey(nl => nl.NotificationId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<NotificationLog>()
                .HasOne(nl => nl.Device)
                .WithMany() 
                .HasForeignKey(nl => nl.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
