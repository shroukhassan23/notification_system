import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class FirebaseService {
  final FirebaseMessaging _messaging = FirebaseMessaging.instance;

  Future<String?> getToken() async {
    return await _messaging.getToken();
  }

  Future<void> registerDevice(String token) async {
    final url = Uri.parse('http://192.168.197.253:5125/api/Device/register');
    final response = await http.post(
      url,
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        'deviceToken': token,
        'deviceName': 'My Flutter Device',
        'registeredAt': DateTime.now().toIso8601String(),
      }),
    );

    if (response.statusCode == 200) {
      print("Device registered successfully!");
    } else {
      print("Failed to register device: ${response.body}");
    }
  }
}
