# JupiterTask Remote Notification System

## Overview
JupiterTask is a **Remote Notification System** that allows sending push notifications from an **Angular Admin Panel** to a **Flutter Mobile Application**. Notifications are stored in a **SQL Server database** and delivered in real-time via **Firebase Cloud Messaging (FCM)**.

The system is structured using **N-Tier Architecture** in the backend and **MVVM** in the Flutter app to ensure clear separation of concerns.

---

## Architecture

### Backend (.NET Core Web API)
- **N-Tier Architecture**
  - **Core Layer**: Entities and interfaces (e.g., `Notification`, `Device`)
  - **Data Access Layer (Repositories)**: Handles database operations
  - **Business Layer (Services)**: Implements business logic
  - **Presentation Layer (Controllers)**: Exposes API endpoints
- **Database**: SQL Server (Code First approach with EF Core)
- **Repository Pattern** and **Dependency Injection**
- **Firebase Integration**: Sends notifications to devices
- **Endpoints**:
  - `POST /api/Notification/send` → Send a new notification
  - `GET /api/Notification` → Fetch all notifications
  - `POST /api/Device/register` → Register a device token

### Angular Admin Panel
- A single page application with:
  - Title input
  - Body input
  - Send Notification button
- Calls backend API to send notifications
- Proper error handling and clean project structure

### Flutter Mobile App
- **MVVM Pattern**
  - **Model**: `NotificationModel`
  - **View**: Screens like `NotificationListScreen`
  - **ViewModel**: Handles state and API calls
  - **Services**: Handles Firebase Messaging and Local Notifications
- Receives push notifications via **Firebase Messaging**
- Displays notifications in the system tray
- Fetches notifications from backend API and displays them in a list
- Business logic is separated from UI

---

## Database Design

### Tables

**Notifications**
| Column    | Type       | Description            |
|-----------|------------|-----------------------|
| Id        | int (PK)   | Primary Key           |
| Title     | string     | Notification title    |
| Body      | string     | Notification body     |
| CreatedAt | datetime   | Creation timestamp    |
| SentBy    | string     | Sent by (e.g., Admin)|
| IsSent    | bool       | Sent status           |

**Devices**
| Column      | Type       | Description           |
|-------------|------------|----------------------|
| Id          | int (PK)   | Primary Key           |
| DeviceToken | string     | FCM device token      |
| DeviceName  | string     | Device name           |
| RegisteredAt| datetime   | Registration timestamp|

**NotificationLogs** *(Optional)*
| Column         | Type      | Description                   |
|----------------|-----------|-------------------------------|
| Id             | int (PK)  | Primary Key                    |
| NotificationId | int (FK)  | Links to Notifications table   |
| DeviceId       | int (FK)  | Links to Devices table         |
| SentAt         | datetime  | Timestamp of sending           |
| Status         | string    | Delivery status                 |

---

## Prerequisites

- .NET SDK 8.0+
- SQL Server (Express or full)
- Node.js & npm
- Angular CLI (`npm install -g @angular/cli`)
- Flutter SDK
- Firebase Project (Service Account JSON for backend)

---

## Setup Instructions

### Backend

1. Open backend project in Visual Studio (VS 2022 recommended).

2. Update `appsettings.json` connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=JupiterTaskDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Install required NuGet packages:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package FirebaseAdmin
```

4. Apply database migrations:

```powershell
Add-Migration InitialCreate
Update-Database
```

5. Place `firebase-service-account.json` at the project root and configure in `Program.cs`:

```csharp
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase-service-account.json")
});
```

6. Register services in `Program.cs`:

```csharp
builder.Services.AddScoped();
builder.Services.AddScoped();
builder.Services.AddScoped();
builder.Services.AddScoped();
builder.Services.AddDbContext(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

7. Run the project. Swagger UI will be available at:

```
https://localhost:5125/swagger/index.html
```

---

### Angular Admin Panel

1. Open the Angular folder in VS Code.

2. Install dependencies:

```bash
npm install
```

3. Update the API URL in `notification.service.ts`:

```typescript
const apiUrl = 'https://localhost:5125/api/Notification';
```

4. Run the project:

```bash
ng serve
```

The Admin Panel will be available at:

```
http://localhost:4200/
```

---

### Flutter Mobile App

1. Open the Flutter folder in VS Code or Android Studio.

2. Install dependencies:

```bash
flutter pub get
```

3. Setup Firebase:
   - Place `google-services.json` in the Android folder
   - Place `GoogleService-Info.plist` in the iOS folder
   - Initialize Firebase in `main.dart`:

```dart
await Firebase.initializeApp();
```

4. Initialize `LocalNotificationService` in `main.dart`.

5. Update the API URL in `api_service.dart`:

```dart
final url = Uri.parse('https://192.168.0.105:5125/api/Notification');
```

6. Run the app:

```bash
flutter run
```

---

## How It Works

1. The Flutter app retrieves its **FCM token** on launch and registers it with the backend via `POST /api/Device/register`
2. The admin opens the Angular panel and sends a notification with a title and body
3. The Angular panel calls `POST /api/Notification/send` on the backend
4. The backend saves the notification to **SQL Server** and sends it to all registered devices via **Firebase Admin SDK**
5. The Flutter app receives the notification through **Firebase Messaging** and displays it via **local notifications**
6. The Flutter app fetches the full notification history from the backend and displays it in a list

---

## Notes

- Make sure **SQL Server Express** is installed and running before starting the backend
- The Flutter app and the backend must be on the **same network** for API calls to work (`192.168.x.x`)
- FCM tokens are managed dynamically by Flutter and re-registered on each app launch
- The backend broadcasts notifications to **all registered devices**
