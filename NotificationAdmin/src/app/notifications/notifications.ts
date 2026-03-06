import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NotificationService } from '../services/notification';

@Component({
  standalone: true,
  selector: 'app-notifications',
  template: `
    <h2>Send Notification</h2>
    <form (ngSubmit)="send()">
      <input type="text" [(ngModel)]="title" name="title" placeholder="Title" required>
      <input type="text" [(ngModel)]="body" name="body" placeholder="Body" required>
      <button type="submit">Send</button>
    </form>
  `,
  imports: [FormsModule, CommonModule]
})
export class NotificationsComponent {
  title = '';
  body = '';
  sentBy = 'Admin';

  constructor(private notificationService: NotificationService) {}

  send() {
    if (!this.title || !this.body || !this.sentBy) return;

    this.notificationService.sendNotification(this.title, this.body, this.sentBy)
      .subscribe({
        next: () => {
          alert('Notification sent!');
          this.title = '';
          this.body = '';
        },
        error: err => {
          console.error(err);
          alert('Error sending notification');
        }
      });
  }
}