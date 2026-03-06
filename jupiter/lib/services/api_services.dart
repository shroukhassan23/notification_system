import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/notification_model.dart';

class ApiService {
  // GET all notifications
  Future<List<NotificationModel>> getNotifications() async {
    final url = Uri.parse('http://192.168.197.253:5125/api/Notification');
    final response = await http.get(url);

    if (response.statusCode == 200) {
      final List data = jsonDecode(response.body);
      return data.map((json) => NotificationModel.fromJson(json)).toList();
    } else {
      throw Exception('Failed to load notifications: ${response.statusCode}');
    }
  }
}
