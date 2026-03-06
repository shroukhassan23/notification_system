import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class NotificationService {
  private apiUrl = 'http://localhost:5125/api/Notification';

  constructor(private http: HttpClient) {}

  sendNotification(title: string, body: string, sentBy: string): Observable<Notification> {
    const payload = { title, body, sentBy };
    return this.http.post<Notification>(`${this.apiUrl}/send`, payload).pipe(
      catchError(err => {
        console.error('Error sending notification:', err);
        return throwError(() => err);
      })
    );
  }

}