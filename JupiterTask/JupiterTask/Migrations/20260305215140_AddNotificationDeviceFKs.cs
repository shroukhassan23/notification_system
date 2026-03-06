using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JupiterTask.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationDeviceFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_DeviceId",
                table: "NotificationLogs",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_NotificationId",
                table: "NotificationLogs",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationLogs_Devices_DeviceId",
                table: "NotificationLogs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationLogs_Notifications_NotificationId",
                table: "NotificationLogs",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationLogs_Devices_DeviceId",
                table: "NotificationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationLogs_Notifications_NotificationId",
                table: "NotificationLogs");

            migrationBuilder.DropIndex(
                name: "IX_NotificationLogs_DeviceId",
                table: "NotificationLogs");

            migrationBuilder.DropIndex(
                name: "IX_NotificationLogs_NotificationId",
                table: "NotificationLogs");
        }
    }
}
