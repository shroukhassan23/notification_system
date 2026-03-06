import { Component, signal } from '@angular/core';
import { NotificationsComponent } from './notifications/notifications';

@Component({
   standalone: true,
  selector: 'app-root',
  template: `<app-notifications></app-notifications>`, 
  imports: [NotificationsComponent]
})
export class App {
  protected readonly title = signal('NotificationAdmin');
}
