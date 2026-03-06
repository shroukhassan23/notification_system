import 'package:flutter/material.dart';
import 'package:jupiter/services/api_services.dart';
import 'package:jupiter/services/firebase_services.dart';
import 'package:provider/provider.dart';
import '../view_models/notification_view_model.dart';

class NotificationListScreen extends StatefulWidget {
  const NotificationListScreen({super.key});

  @override
  State<NotificationListScreen> createState() => _NotificationListScreenState();
}

class _NotificationListScreenState extends State<NotificationListScreen> {
  late final NotificationViewModel notificationViewModel;

  @override
  void initState() {
    super.initState();
    notificationViewModel = NotificationViewModel(
      ApiService(),
      FirebaseService(),
    );
    notificationViewModel.fetchNotifications(); // fetch notifications
    _registerDeviceToken();
  }

  Future<void> _registerDeviceToken() async {
    await notificationViewModel.registerDeviceToken();
  }

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider.value(
      value: notificationViewModel,
      child: Scaffold(
        appBar: AppBar(title: const Text("Notifications")),
        body: Consumer<NotificationViewModel>(
          builder: (context, vm, child) {
            if (vm.loading) {
              return const Center(child: CircularProgressIndicator());
            }

            if (vm.notifications.isEmpty) {
              return const Center(child: Text("No notifications"));
            }

            return RefreshIndicator(
              onRefresh: () async {
                await vm.fetchNotifications();
              },
              child: ListView.builder(
                itemCount: vm.notifications.length,
                itemBuilder: (context, index) {
                  final notification = vm.notifications[index];
                  return ListTile(
                    title: Text(notification.title),
                    subtitle: Text(notification.body),
                  );
                },
              ),
            );
          },
        ),
      ),
    );
  }
}
