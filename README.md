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
