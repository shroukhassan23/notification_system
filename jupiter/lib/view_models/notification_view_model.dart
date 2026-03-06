import 'package:flutter/material.dart';
import 'package:jupiter/models/notification_model.dart';
import 'package:jupiter/services/api_services.dart';
import 'package:jupiter/services/firebase_services.dart';

class NotificationViewModel extends ChangeNotifier {
  List<NotificationModel> notifications = [];
  final ApiService apiService;
  final FirebaseService firebaseService;

  NotificationViewModel(this.apiService, this.firebaseService);
  bool loading = false;
  Future<void> fetchNotifications() async {
    loading = true;
    notifyListeners();

    try {
      notifications = await apiService.getNotifications();
    } catch (e) {
      print("Error fetching notifications: $e");
    } finally {
      loading = false;
      notifyListeners();
    }
  }

  Future<void> registerDeviceToken() async {
    final token = await firebaseService.getToken();
    if (token != null) {
      await firebaseService.registerDevice(token);
    }
  }
}
