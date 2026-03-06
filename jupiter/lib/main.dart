import 'package:flutter/material.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:jupiter/services/local_notifications_services.dart';
import 'package:jupiter/services/notification_services.dart';
import 'package:jupiter/views/notification_list_screen.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp();
  await LocalNotificationService.init();
  await NotificationService.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      home: NotificationListScreen(),
    );
  }
}
